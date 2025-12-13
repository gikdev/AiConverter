const fs = require('fs');

// Load JSON files
const original = JSON.parse(fs.readFileSync('original.json', 'utf8'));
const oldOnes = JSON.parse(fs.readFileSync('old.json', 'utf8'));
const newOnes = JSON.parse(fs.readFileSync('new.json', 'utf8'));

// Convert AI outputs to dictionary by id for easy lookup
const oldOnesMap = Object.fromEntries(oldOnes.map(item => [item.id, item]));
const newOnesMap = Object.fromEntries(newOnes.map(item => [item.id, item]));

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
  const oldOne = oldOnesMap[id] || null
  const newOne = newOnesMap[id] || null

  if (original && 'Id' in original) delete original.Id
  if (oldOne && 'id' in oldOne) delete oldOne.id
  if (newOne && 'id' in newOne) delete newOne.id

  return { id, original, oldOne: oldOne, newOne: newOne };
});

// Save merged JSON
fs.writeFileSync('merged.json', JSON.stringify(merged, null, 2), 'utf8');
console.log('Merged JSON saved as merged.json');
