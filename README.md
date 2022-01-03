Unity Card Game
---------------
**Name:** Brett Austin  
  **Directory Structure:** `Unity-Card-Game/Assets/Scripts/` contains the entirety of the code sample. If looking for a comprehensive portion of the sample in a single file, see `Unity-Card-Game/Assets/Scripts/Base/Controllers/DeckTester.cs`.\
  **Explanation of Code Sample:** A card game with a deck system that includes a discard pile, normal deck, and a player hand that used UI to show 3 playable cards and the most recent card added to the discard pile to the player. The player faces off against an enemy AI and tries to get the health of the enemy to 0 before their own reaches 0.
  - A) Main menu with ability to click buttons for:
      - Start game, which transfers them to the game scene
      - Settings menu, which contains a slider that controls music volume. The slider value is held as a PlayerPref, which allows it to be saved and remembered in case the game is played again
      - Exit game, to quit the playable Unity executable
  - B) Basic music player that plays one track for the main menu and switches to another once the game scene is loaded
  - C) Audio and visual feedback for:
      - New player turn (AKA each time the enemy state switches back to the player state)
      - Card being drawn
      - Card being placed
      - Card being selected (AKA cursor hovering over the card)
      - Card being clicked (AKA cursor clicking on the card)
      - Play card button being clicked
  - D) Player's hand of 3 cards shifts to the left once an existing card is used, with the new card drawn immediately after taking the place of the furthest right of the 3 cards
  - E) Functioning enemy AI that presents a reasonable challenge, done through randomized picks of standard damage cards
  - F) State transitions for player and enemy turns as well as win/loss state implementation
  - G) Player actions put onto clickable buttons to simplify necessary user input and control scheme
  - H) Deck that automatically shuffles once it reaches 0 cards
  - I) Card variety with 5 different play effects consisting of:
      -  Standard Damage Cards
      -  Negate Damage Cards
      -  Double Damage Cards
      -  Healing Cards
      -  Reflect Damage Cards

**Date when Code was Written (Excluding Updates to Readme):**\
First Commit (Initially done outside of GitHub): October 15, 2020\
Final Commit: November 23, 2020
