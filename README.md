# **Resident Evil - 3D Video Game (Inspired by Resident Evil)**

## **Project Overview**  
This project is a 3D video game inspired by the original *Resident Evil*, developed using **Unity**. The main focus was on creating a survival horror experience with classic gameplay elements such as object collection, enemy AI, and scene transitions. The game emphasizes optimized performance, smooth user interaction, and dynamic elements that make each playthrough unique.

## **Features and Components**

### **1. Scene Transitions with Singleton Pattern**  
To ensure seamless transitions between scenes and maintain game state data (such as player health, inventory, and progress), we implemented the **Singleton pattern**. This allowed us to keep consistent data across all scenes without needing to reinitialize data when loading new levels.

### **2. Zombie Enemies with AI**  
The game features zombies with basic **AI**, where they roam the environment and chase the player once within proximity. We applied pathfinding and state machine concepts to ensure that zombies react dynamically to the player's movements, providing a challenging and immersive experience.

### **3. Auto-Generation of Zombies**  
To add variety and unpredictability, zombies are **auto-generated** in different areas of the map based on certain conditions, such as player location or random spawn points. This increases replayability, as the player cannot predict where enemies will appear next.

### **4. Puzzle System**  
The game includes a puzzle system where the player must collect a series of objects that provide clues for the next steps to progress. These objects are key to solving the puzzle and unlocking new areas of the game.

### **5. Interactive Inventory**  
The **inventory system** was created using Unity's UI tools. Players can store key objects in their inventory and access them as needed to solve puzzles or progress through the game. The inventory was designed to be intuitive, with an easy-to-navigate visual system.

## **Technologies Used**
- **Unity** (Game Engine)
- **C#** (Programming Language)
- **GitHub** (Version Control and Collaboration)

## **How to Play**
- Use **WASD** to move the player.
- Left-click to attack enemies and interact with objects.
- Collect key objects that will be stored in the **inventory** and provide clues for the next steps.
- Beware of the zombies, who will chase you.

## **Installation Instructions**
1. Clone the repository:  
   ```bash
   git clone https://github.com/yourusername/Resident-Evil-3D-Game.git
   ```
2. Open the project in **Unity**.
3. Build and run the game.

## **Contributors**
- **Santiago Mejía**
- **Jean Carlo Chantre**
- **Steven Camilo Franco**
