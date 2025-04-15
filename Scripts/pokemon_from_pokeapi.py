import requests
import time

output_path = "pokemon_insert_extended.sql"
pokemon_list = []

def get_english_description(species_data):
    for entry in species_data.get("flavor_text_entries", []):
        if entry["language"]["name"] == "en":
            return entry["flavor_text"].replace("\n", " ").replace("\f", " ").replace("'", "''").strip()
    return ""

def get_evolution_chain_ids(evolution_data):
    chain = evolution_data["chain"]
    ids = []

    def traverse(node):
        url = node["species"]["url"]
        poke_id = int(url.rstrip("/").split("/")[-1])
        ids.append(poke_id)
        for evo in node["evolves_to"]:
            traverse(evo)

    traverse(chain)
    return ids

print("🔄 Iniciando descarga de Pokémon...")

for i in range(1, 152):
    print(f"📦 Procesando Pokémon ID {i}...")

    poke = requests.get(f"https://pokeapi.co/api/v2/pokemon/{i}").json()
    species = requests.get(f"https://pokeapi.co/api/v2/pokemon-species/{i}").json()
    evo_url = species["evolution_chain"]["url"]
    evolution = requests.get(evo_url).json()

    evo_chain = get_evolution_chain_ids(evolution)
    index = evo_chain.index(i)
    evolves_from = evo_chain[index - 1] if index > 0 else "NULL"
    evolves_to = evo_chain[index + 1] if index < len(evo_chain) - 1 else "NULL"

    stats = {s["stat"]["name"]: s["base_stat"] for s in poke["stats"]}
    types = [t["type"]["name"].capitalize() for t in poke["types"]]
    type1 = types[0]
    type2 = f"'{types[1]}'" if len(types) > 1 else "NULL"

    print(f"   🧬 {poke['name'].capitalize()} - Tipos: {types} - Evoluciona de: {evolves_from}, a: {evolves_to}")

    insert = f"""(
        {i},
        '{poke["name"].capitalize()}',
        '{type1}',
        {type2},
        {stats["attack"]},
        {stats["defense"]},
        {stats["special-attack"]},
        {stats["special-defense"]},
        {stats["speed"]},
        {stats["hp"]},
        '{get_english_description(species)}',
        {poke["height"] / 10},
        {poke["weight"] / 10},
        '{poke["sprites"]["front_default"]}',
        {evolves_from},
        {evolves_to}
    )"""
    pokemon_list.append(insert)
    time.sleep(0.2)

# SQL limpio sin alter table
header = """
USE PokeApiDb;
GO

SET IDENTITY_INSERT [dbo].[Pokemons] ON;

INSERT INTO Pokemons (
    Id, Name, Type1, Type2, Attack, Defense, SpecialAttack, SpecialDefense, Speed, HP,
    Description, Height, Weight, ImageUrl, EvolvesFrom, EvolvesTo
) VALUES
"""

with open(output_path, "w", encoding="utf-8") as f:
    f.write(header)
    f.write(",\n".join(pokemon_list))
    f.write(";")

print(f"\n✅ Script SQL generado correctamente en: {output_path}")
