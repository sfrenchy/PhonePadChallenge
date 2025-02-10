# Old Phone Text Converter

Hey! This is my implementation of an old phone text converter (like old Nokia phones with T9). 
You know, when you had to press 2 multiple time to get 'A', 'B' or 'C'.

## What it does
- Convert numbers to text like old phones
- Can delete chars with '*'
- Handle spaces
- Make sure input is correct
- Clean code (I try my best!)
- Two different implementations (why not!)
- Can convert text back to key press too

## How to use it
It's pretty simple:
- Use numbers 2-9 for letters
- Press multiple time for different letters (like 2 one time for A, two time for B)
- Use '*' to delete last letter (when you make mistake)
- End your message with '#'
- Use '0' or space for... well, spaces

The keys work like this:

\`\`\`
1: &'(    2: ABC    3: DEF
4: GHI    5: JKL    6: MNO
7: PQRS   8: TUV    9: WXYZ
0: space
\`\`\`

### Examples

#### Convert:
\`33#\` gives you "E" (press 3 two times)
\`227*#\` gives you "B" (press 2 two times, ignore 7 because of *)
\`8 88777444666*664#\` gives you "TURING"

#### Reverse:
"TURING" gives you \`8 88777444664#\` (cool, right?)
"HELLO" gives you \`4433555 555666#\`
"CAB" gives you \`222 2 22#\`

## Technical stuff (if you want to know more)
I use C# (.NET 8.0) and JetBrains Rider (best IDE ever!) to make it:
- Easy to understand
- Not too complex
- Ready for changes
- With good error messages
- Using dependency injection to switch implementations

The code check for:
- Empty inputs (cant convert nothing!)
- Missing '#' at end
- Wrong characters
- Too long inputs

## About the implementations
I make two different versions because I wanna to try different approaches:

### 1. LINQ Version (OldPhonePadLinqConverter):
- Use LINQ to group characters
- More clean style
- Maybe bit slower but code is nice
- Split logic in small methods
- Good to show LINQ skills
- I try this because I did technical test before with LINQ
  for Morse code conversion and it work good, so why not here!

### 2. Iterative Version (OldPhonePadIterativeConverter):
- Classic loop way
- More fast probably
- Easy to understand if you dont know LINQ
- Easy to debug
- Work in all languages

Both do same thing, just different way. I do both because:
- Fun to compare
- Show I can do things different ways
- Each one has good and bad things
- Real projects need different solutions sometimes

Then I think: "Why not add Reverse?" So I do it! Was fun to make text go back 
to key press. I put it in base class because it work same for both versions.
Rider help me organize all this code nice and clean (love this IDE!).

## Things I could add later
- More tests
- Support other languages
- Faster for big inputs
- Other keyboard layouts maybe
- Async support (but need it?)
- Compare speed of both versions
- Try other way for reverse convert

Feel free to use code or say how to make better! 

Note: Code use Constants class to not repeat stuff, and both implementations 
use dependency injection. Nice no?
