﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    class GameplayOperations // this is a class
    {
        private static string[] AnimalData()
        {
            //animals name for game operators
            string[] animals = new string[] {
                "Aardvark",
                "Albatross",
                "Alligator",
                "Alpaca",
                "Ant",
                "Anteater",
                "Antelope",
                "Ape",
                "Armadillo",
                "Donkey",
                "Baboon",
                "Badger",
                "Barracuda",
                "Bat",
                "Bear",
                "Beaver",
                "Bee",
                "BlueWhale",
                "Bison",
                "Boar",
                "Buffalo",
                "Bull",
                "Butterfly",
                "Camel",
                "Capybara",
                "Caribou",
                "Cassowary",
                "Cat",
                "Caterpillar",
                "CatFish",
                "Cattle",
                "Chamois",
                "Cheetah",
                "Chicken",
                "Chimpanzee",
                "Chinchilla",
                "Chough",
                "Clam",
                "Cobra",
                "Cockroach",
                "Cod",
                "Cormorant",
                "Coyote",
                "Crab",
                "Crane",
                "Crocodile",
                "Crow",
                "Curlew",
                "Deer",
                "Dinosaur",
                "Dog",
                "Dogfish",
                "Dolphin",
                "Donkey",
                "Dotterel",
                "Dove",
                "Dragonfly",
                "Duck",
                "Dugong",
                "Dunlin",
                "Eagle",
                "Echidna",
                "Eel",
                "Eland",
                "Elephant",
                "Elk",
                "Emu",
                "Falcon",
                "Ferret",
                "Finch",
                "Fish",
                "Fly",
                "Fox",
                "Frog",
                "Gaur",
                "Gazelle",
                "Gerbil",
                "Giraffe",
                "Gnat",
                "Gnu",
                "Goat",
                "Goldfinch",
                "Goldfish",
                "Goose",
                "Gorilla",
                "Goshawk",
                "Grasshopper",
                "Grouse",
                "Guanaco",
                "Gull",
                "Hamster",
                "Hare",
                "Hawk",
                "Hedgehog",
                "Heron",
                "Herring",
                "Hippopotamus",
                "Hornet",
                "Horse",
                "Human",
                "Hummingbird",
                "Hyena",
                "Ibex",
                "Ibis",
                "Jackal",
                "Jaguar",
                "Jay",
                "Jellyfish",
                "Kangaroo",
                "Kingfisher",
                "Koala",
                "Kookabura",
                "Kouprey",
                "Kudu",
                "Lapwing",
                "Lark",
                "Lemur",
                "Leopard",
                "Lion",
                "Llama",
                "Lobster",
                "Locust",
                "Loris",
                "Louse",
                "Lyrebird",
                "Magpie",
                "Mallard",
                "Manatee",
                "Mandrill",
                "Mantis",
                "Marten",
                "Meerkat",
                "Mink",
                "Mole",
                "Mongoose",
                "Monkey",
                "Moose",
                "Mosquito",
                "Mouse",
                "Mule",
                "Narwhal",
                "Newt",
                "Nightingale",
                "Octopus",
                "Okapi",
                "Opossum",
                "Oryx",
                "Ostrich",
                "Otter",
                "Owl",
                "Oyster",
                "Panther",
                "Parrot",
                "Partridge",
                "Peafowl",
                "Pelican",
                "Penguin",
                "Pheasant",
                "Pig",
                "Pigeon",
                "Pony",
                "Porcupine",
                "Porpoise",
                "Quail",
                "Quelea",
                "Quetzal",
                "Rabbit",
                "Raccoon",
                "Rail",
                "Ram",
                "Rat",
                "Raven",
                "Red deer",
                "Red panda",
                "Reindeer",
                "Rhinoceros",
                "Rook",
                "Salamander",
                "Salmon",
                "Sand Dollar",
                "Sandpiper",
                "Sardine",
                "Scorpion",
                "Seahorse",
                "Seal",
                "Shark",
                "Sheep",
                "Shrew",
                "Skunk",
                "Snail",
                "Snake",
                "Sparrow",
                "Spider",
                "Spoonbill",
                "Squid",
                "Squirrel",
                "Starling",
                "Stingray",
                "Stinkbug",
                "Stork",
                "Swallow",
                "Swan",
                "Tapir",
                "Tarsier",
                "Termite",
                "Tiger",
                "Toad",
                "Trout",
                "Turkey",
                "Turtle",
                "Viper",
                "Vulture",
                "Wallaby",
                "Walrus",
                "Wasp",
                "Weasel",
                "Whale",
                "Wildcat",
                "Wolf",
                "Wolverine",
                "Wombat",
                "Woodcock",
                "Woodpecker",
                "Worm",
                "Wren",
                "Yak",
                "Zebra"
            };
            return animals;//return value
        }

        private static IEnumerable<string> GetAnimals(string[] animals)
        {
            List<string> listNames = new List<string>();

            foreach (string animal in animals)
            {
                listNames.Add(animal.ToLower());
            }
            return listNames;
        }

        private static int RandomNumber(int maximumLength)
        {
            Random myRandom = new Random();
            int randNum = myRandom.Next(0, maximumLength);
            return randNum;
        }

        public static string GetRandomWord()
        {
            //get random animal name while play
            List<string> Words = new List<string>();
            Words.AddRange(GetAnimals(AnimalData()));
            return Words[RandomNumber(Words.Count)];
        }
    }
}