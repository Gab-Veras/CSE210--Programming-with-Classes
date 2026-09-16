What does the program do?
It is a journal reminder/helper app. It is supposed to help people to see the habbit of writing a journal easier.

What user inputs does it have?
Selection of options with numbers.
Text to store in the journal.
File name to be stored the journal

What output does it produce?
A list of choices.
The journal entries displayed with text>prompt>date
A document that register all entries.

How does the program end?
When the user select the "quit" option.

--------

Classes:

- Main
  - Menu {list}
  - Will handle all the menu functions
  - Display all the menu function
- Journal 
  - Save the entry {String}
    - Will ask the file to save in
    - Will select the the file 
    - save into it
  - Add entry {string}
    - Will open the space to type the text
    - Will add the date of the entry
  - Display all the entries {void}
    - Will access the loaded file
    - Display all the content from this file
- Entries {list}
  - Store all current entries (still not saved)
  - Display if asked
- Load {void}
  - Will ask the name of the file to load from
  - Encounter the file
  - Set this file to start
- Prompt generator {list}
  - Will have a list of prompts
  - Will randonly display one of the prompts (it cannot be repeted)

