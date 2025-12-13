const fs = require('fs');

// Load JSON files
const original = JSON.parse(fs.readFileSync('original.json', 'utf8'));
const gpt5 = JSON.parse(fs.readFileSync('gpt5.json', 'utf8'));
const gpt51 = JSON.parse(fs.readFileSync('gpt51.json', 'utf8'));

// Convert AI outputs to dictionary by id for easy lookup
const gpt5Map = Object.fromEntries(gpt5.map(item => [item.id, item]));
const gpt51Map = Object.fromEntries(gpt51.map(item => [item.id, item]));

// Merge
const merged = original.map(item => {
  const id = item.Id.toLowerCase()

  const original = {
    ot: item.Title,
    kw: [
      item.KeyWord,
      item.KeyWord2,
      item.KeyWord3,
      item.KeyWord4,
      item.KeyWord5,
    ]
  }
  const gpt5 = gpt5Map[id] || null
  const gpt51 = gpt51Map[id] || null

  if (original && 'Id' in original) delete original.Id
  if (gpt5 && 'id' in gpt5) delete gpt5.id
  if (gpt51 && 'id' in gpt51) delete gpt51.id

  return { id, original, gpt5, gpt51 };
});

// Save merged JSON
fs.writeFileSync('merged.json', JSON.stringify(merged, null, 2), 'utf8');
console.log('Merged JSON saved as merged.json');
