# Zaman Perang: A Historical Journey through Singapore

### Team Name: SawBros

![Zaman Perang Logo](path/to/your/logo.png) <!-- Replace with the actual path to your logo image -->

---

### Table of Contents
1. [Motivation](#motivation)
2. [Vision](#vision)
3. [Storyline](#storyline)
4. [User Stories](#user-stories)
5. [Scope of Project](#scope-of-project)
6. [Features](#features)
7. [Timeline and Development Plan](#timeline-and-development-plan)
8. [Class Diagram](#class-diagram)
9. [Proof-of-Concept](#proof-of-concept)
10. [Work Log](#work-log)
11. [Installation and Setup](#installation-and-setup)
12. [Contributing](#contributing)
13. [License](#license)

---

### Motivation
Our passion for blending education with immersive experiences drives the development of **Zaman Perang**. We aim to create an engaging platform where users learn about Singaporean history through interactive gameplay. This approach transforms historical learning into a captivating and enjoyable experience, moving beyond traditional textbook methods.

### Vision
**Zaman Perang** is a 2D base defense strategy game built using the Unity Game Development Environment. Inspired by classic games like "Age of War" and "The Battle Cats," our goal is to create a simple and enjoyable game that educates players about Singapore's history. By incorporating a retro style, we hope to evoke a sense of nostalgia, making the learning experience both engaging and memorable.

### Storyline
**Zaman Perang** takes players through pivotal eras of Singapore's history, from the 12th century to the present and into the future. Each era features unique characters and special moves:

- **Early Settlements Age**: Witness the founding of Singapore by Sang Nila Utama.
- **British Colonial Age**: Experience the transformation into a bustling port city.
- **World War II Age**: Face the challenges of the Japanese occupation.
- **Independence Age**: Guide the nation through its struggle for self-governance.
- **Current & Futuristic Age**: Explore contemporary and future Singapore.

Players can pause to read detailed historical information, deepening their understanding of each era.

### User Stories
As a player, I want:
- A nostalgic and visually pleasing retro art style.
- An engaging and educational storyline about Singapore's history.
- Challenging gameplay that requires strategic thinking.
- Options for difficulty and character development.
- A balanced system where different strategies can lead to victory.
- A game that is easy to pick up and understand.
- Clear tutorials and guidance to avoid confusion.
- The ability to pause and read historical information during gameplay.

### Scope of Project
**Zaman Perang** is a 2D, left-to-right tower defense game. The objective is to protect your base while destroying the enemy’s. Players manage their economy by earning currency from defeating enemies and wisely spending it on defenses and unit deployments.

### Features

#### Base Defense [Current Progress]
- **Objective**: Defend your base from enemy units and destroy the enemy base.
- **Health Display**: Both bases have visible health bars.
- **Health Pool Enhancement**: Increase base health through the prestige system.
- **Strategic Defense**: Build turrets and fortifications.
- **Offensive Strategy**: Deploy units to attack the enemy base.

#### Game Currencies [To be Implemented]
- **Zaman Perang Dollar (ZP$)**: Used for deploying units and building structures.
- **Experience Points (EXP)**: Used to unlock prestige levels and upgrade the base and units.

#### Characters [Current Progress]
Each era features unique units with varying stats and abilities:

| Age                    | Class (Name)      | Attack | Defence | Range    | Cost (ZP$) |
|------------------------|-------------------|--------|---------|----------|------------|
| **Early Settlements**  | Fisherman         | 5      | 3       | Melee    | 20         |
|                        | Sang Nila Utama   | 6      | 4       | Ranged   | 35         |
|                        | Lion Rider        | 7      | 8       | Melee    | 110        |
| **British Colonial**   | British Soldier   | 8      | 7       | Melee    | 65         |
|                        | Rifleman          | 10     | 5       | Ranged   | 80         |
|                        | Sir Stamford Raffles | 7   | 8       | Melee    | 200        |
| **World War II**       | Civilian          | 6      | 4       | Melee    | 200        |
|                        | Resistance Fighter | 10   | 10      | Melee    | 350        |
|                        | Japanese Soldier  | 12     | 8       | Ranged   | 500        |
| **Independence**       | Freedom Fighter   | 8      | 7       | Melee    | 1100       |
|                        | Celebrator        | 9      | 6       | Ranged   | 1750       |
|                        | Lee Kuan Yew      | 11     | 12      | Melee    | 3000       |
| **Current & Future**   | Infantry Soldier  | 10     | 8       | Ranged   | 7500       |
|                        | Leopard 2SG       | 14     | 15      | Ranged   | 13000      |
|                        | AI Robot          | 18     | 10      | Melee    | 17500      |
|                        | Super Soldier     | 30     | 30      | Melee    | 100000     |

#### Special Moves [To be Implemented]
Overpowered skills with long cooldowns for each era:

- **Early Settlements**: Lion Roar
- **British Colonial**: Cannon Barrage
- **World War II**: Artillery
- **Independence**: Rally of Independence
- **Current & Future**: Ion Ray

#### Player UI [Current Progress]
- **Unit Deployment Menu**
- **Turret Menu**
- **Add Turret Spot**
- **Prestige Button**
- **Special Move Button**
- **Currency Display**
- **Historical Information on Hover** (to be implemented)

#### Historical Context [To be Implemented]
- **Main Menu Button**: Overview of historical context.
- **Pause Menu Button**: Detailed era-specific information.
- **Mouse Hover Over Units**: Brief historical facts and descriptions.

#### Enemy Deployment System [Current Progress]
- **Current**: Predetermined generation using timers.
- **Future**: Randomized deployment or AI-based enemy strategy.

#### Turrets [To be Implemented]
- **Infinite Ammunition**
- **Economic Strategy**
- **Income Generation**
- **Turret Upgrades**

### Timeline and Development Plan
Our plan to complete the game in the next two milestones:

| Milestone | Task | Description | Assignee | Date |
|-----------|------|-------------|----------|------|
| **1** | Preliminary Research | Familiarize with Unity, tower defense mechanics | Isaac, Ivan | May 6 - May 12 |
|        | Concept Art | Placeholder art for sprites | Isaac | May 13 - May 19 |
|        | Menus | Create main menu, game scene, UI concept | Ivan | May 20 - May 26 |
|        | Battle Mechanics | Implement unit generation and conflict logic | Ivan | May 27 - June 2 |
| **2** | Currency System | Implement ZP$ and EXP; balance game currency | Isaac | June 3 - June 16 |
|        | Game Systems | Implement turrets and special moves | Ivan | June 17 - June 30 |
|        | Special Moves | Design overpowered skills for each age | Isaac | June 17 - June 30 |
|        | Integration | Integrate systems | Ivan, Isaac | July 1 - July 7 |
| **3** | Character Design | Create sprite sheets | Isaac | July 1 - July 7 |
|        | Enemy AI | Finalize deployment algorithm | Ivan | July 8 - July 14 |
|        | Refinement | Testing and debugging | Isaac, Ivan | July 15 - July 21 |

### Class Diagram
![Class Diagram](https://drive.google.com/file/d/12VHu5jSSSifixw2jFU5KBElOaFw5ixD6/view?usp=sharing) <!-- Replace with the actual path to your class diagram image -->

We plan to restructure the system, consolidating friendly and enemy units into a single troop class and using a universal health tracker. Improvements will be made by Milestone 2.

### Proof-of-Concept
Watch our [video demonstration](https://youtu.be/_HTTFTMVQKE?si=nfX2I-oca7M5oNkv).

### Work Log
Check out our detailed [work log](https://docs.google.com/spreadsheets/d/1rxdkh0BpwTsG5GMPbIyYOaFecrJv6cWUsyR2RYxZ9-M/edit?usp=sharing).

### Installation and Setup
To set up **Zaman Perang** on your local machine:

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/zaman-perang.git
