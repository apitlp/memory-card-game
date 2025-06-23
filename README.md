# Memory Card Game

Memory Card Game (MCG) is a project created during laboratory work on Software Modelling and Analysis. It aims to demonstrate skills of using software design patterns of all groups - creational, structural, and behavioural - and C# programming skills, especially OOP in C#.

About the project:
-

MGC is a two-player game in which all of the cards are laid face down on a surface and two cards are flipped face up over each turn. The object of the game is to turn over pairs of matching cards. For each pair player gains a point. Each turn is limited in time, so players have to be not only attentive, but quick too!

MGC develops the classic game by adding various bonuses (additional time, additional point) and debuffs (time reduction, point reduction). Also, players can configure level on their manner by setting custom number of cards and time per turn. And, as the icing on the cake, the game uses "italian brainrot" theme and has an audio for each card :) 

About used patterns:
- 

**Creational patterns:**
  - Abstract Factory - used for proccess of creation of cards objects
  - Prototype - provides cloning of existing cards instances in the factory
  - Builder - constructs level configuration
  - Singleton - manages the game logic

**Structural patterns:**
  - Facade - provides a unified interface for reading user input of configuration and constructing the corresponding level
  - Decorator - wraps a card by adding audio to it
  - Proxy - provides a placeholder for audio

**Behavioural patterns:**
 - Observer - used for linking UI layer and the game logic layer
 - Strategy - provides simple algorithm substitution in bonus and debuff cards
 - Chain of Responsibility - determines type of a card and invokes respective actions


