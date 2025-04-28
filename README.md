# Witch Doctor Game README

## General Gameplay Goals

In each round, a new patient arrives at the doctor’s office. The goal is to successfully identify all three phases of evidence and create a potion to cure the patient. Potions require three ingredients, each corresponding to one phase of evidence. If the player fails to correctly cure the patient, they receive one of three possible strikes. Once the player accumulates three strikes, the game ends. However, if all 27 potions are created successfully, the witch doctor will "win."

### Player Incentives:
- **Interact with Unique Characters**: Engage with interesting characters in a captivating fantasy world.
- **Diagnose and Cure Patients**: Use intuitive mini-games and environmental clues to correctly identify evidence.
- **Potion Creation**: Combine ingredients in an engaging potion-making mechanic.
- **Discover All Potions**: Collect all unique potion designs by diagnosing various monsters to win the game.
- **(Stretch Goal)**: Unveil more about the doctor and the monsters through splash art and dialogue between rounds.

## Evidence Collection

### Phase 1: Monster Species
The first ingredient in the potion depends on the species of the monster. Each species requires its own unique ingredient, which remains consistent throughout the game.

**Monster Ingredients**:
- **Orc**: Muscle of Boar
- **Vampire**: Blood of Goat
- **Demon**: Eye of Evil

### Phase 2: Diagnosis and Symptom Groups
Each unique symptom corresponds to one specific ingredient. The first three symptoms come from the initial consultation and cannot be tested (Symptom Group A). When a patient arrives, they will disclose one of the three randomly generated Group A symptoms.

#### Symptom Group A:
- **Runny Nose**
- **Monster Cough**
- **Sore Bones**

### Phase 3: Tests and Completion
To complete the diagnosis, the player must run two tests (mini-games). The last three pieces of evidence come from these tests (Symptom Group B).

#### Symptom Group B:
- **Fizzling Spells**
- **Flaming Fever**
- **Fickle Heartbeat**

### Monster-Specific Ingredients:
- **Orc**: Muscle of Boar
- **Vampire**: Blood of Goat
- **Demon**: Eye of Evil

#### Symptoms & Ingredients:
- **First Symptom**:
  - **Wool of Bat** (Brown)
  - **Toe of Frog** (Green)
  - **Scale of Dragon** (Red)
  
- **Second Ingredient**:
  - **Magic Crystal** (Fizzling Spells)
  - **Ice Slime** (Flaming Fever)
  - **Mandrake Root** (Fickle Heart)

## Mini-Games

### 1. Spell Check (Fizzling Spells)
In this micro-minigame, the player clicks and holds a button while a meter charges. When the meter reaches full capacity, the player releases their click, causing the patient to shoot a magic bolt from their finger. If the spell is weak, the patient is positive for "fizzling spells." If the spell has normal strength, the patient is negative for "fizzling spells."

### 2. Temp Check (Flaming Fever)
This micro-minigame requires the player to drag an icon across a bar to align it with a designated “success area.” When the player releases the icon, a wand will appear to take the patient’s temperature. If the wand erupts in flames, the patient is positive for "flaming fever." If the wand does not react, the patient is negative for "flaming fever."

### 3. Vital Check (Fickle Heartbeat)
In this mini-game, the player must hover over the heart area of the monster's silhouette on-screen. If the heartbeat sound is growling, the patient is positive for a "fickle heartbeat." If the heartbeat sound is normal, the patient is negative for a "fickle heartbeat." Visual cues such as red or green icons can be added for accessibility if needed.

## Potion Creation

Potion creation involves a drag-and-drop mechanic where players select the correct ingredients based on the symptoms they've identified. Each symptom is matched to a corresponding ingredient listed on a clickable piece of paper. The potion creation screen features a visually engaging UI for an intuitive and fun experience.

---

**Game Repository:**  
You can find the source code and contribute to the project here:  
[GitHub Game Repository](https://github.com/cmsc-vcu/gamedev-fa2024-final-vanct2)

