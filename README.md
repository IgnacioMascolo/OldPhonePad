# Old Phone Pad – C# Coding challenge

The solution to the "Old Phone Pad" challenge by Iron Software for a coding challenge.

# Objective
Simulate and Old Style Phone, decoding input from the user
Rules:
- Available characters by pressing the number key an odd number of times (e.g., `2` → A, `22` → B, `222` → C).
- Pressing `*` deletes the most recently entered character (backspace).
- Pressing `0` inserts a blank character
- Space (character `' '` in the input) indicates a pause of time between diﬀerent characters on the same key.
- If any invalid sequence is requested to be entered (eg. `"77777"`), then we print: `"???"`
- The message is always terminated by a `#` and if  is not there, then function outputis `“No message was sent because the '#' 
Character is missing":`

---

# Examples

| Input | Output |
|-------|-------|
| "222 2 22#" | "CAB" |
| "#" | EMPTY |
| "4433555  555666#" | "HELLO" |


---

# Launching
In order to launch the program, open the terminal (CTRL + J) and writte: dotnet run. That will start the program


# Tests

Code includes the implementation a "RunTests()" method consisting of test cases to run the logic.

If you want to use it, launch the Program and in the beggining you can choose if you want to use the old phone by your own or if you want to run the test, by entering "y"
