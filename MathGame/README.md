# Math

this project was developed as part of csharp-academy challenge and doesn't represent a core or a useful business product however you can use it to play with your children and young siblings who happened to be a computer nerd but will not receive any further core update but pull requests are welcomed

this project was a real testing playground to measure what really I can do with this language keep in mind that my level is beginner by the time of writing this repo with previous experience in python and basic understanding in c++ and java (don't ever try learning java 8)

I didn't plan to make it full oop and I was gonna make a monolithic class  with many many partial members but I discarded the idea and refactored everything into oop base

and to be honest I didn't planned to make it fully function TUI but I guess I love over-engineering stuff always and over think it

## to the csharp-academy mentors reviewing my project

please guide me through how to plan your project structure and what type of problems generally in programming exercise but please I want guidance on how to think not like a coder like a system designer how to make multiple components communicate with each other and lastly I want an objective brutally honest review thing I can do better based on my current knowledge thing I shouldn't have done am not aiming for praises I want to get a jop in the .net marked and it to be a key for getting outside of my home country so I want to know what wrong and what right to enhance myself

I truly appreciate your review in advance.

## AI honesty

about 60% of feature was designed and planned by me however due to the level of inexperience in debugging generally and c# specifically and to be honest I used the debugger sometimes to watch how my variables change to guess the issue and in other times I would simply trace it if it's simple and proceed in random changes till it  got fix magically

however due to inexperience in code deigning and how to connect my ideas some features like dictionary, using abstract class, using interfaces and workarounds to pass the threading locks such as readline or looping to get the timer, orchestrating multiple objects through interface, using Enums, searching a better way of generating random number and shuffling them, better code optimizations and lastly as I remember how to wire your ideas into robust execution

however I'm not a big fan of copy pasting sense I learn by search , read and apply so I wrote almost all the code by hand but I used rider's built-in tools to help in code refactoring

## commit philosophy

I followed when committing Conventional Commits.Standard Commit Structure

```text
<type>[optional scope]: <description>
```

- Common Commit Types
  - feat: A new feature for the user.
  - fix: A bug fix for the user.
  - docs: Changes to the documentation.
  - style: Formatting, missing semi-colons, etc. (no production code changes).
  - refactor: Refactoring production code (neither fixing a bug nor adding a feature).
  - perf: Code changes that improve performance.
  - test: Adding missing tests or correcting existing tests.
  - build: Changes that affect the build system or external dependencies.
  - ci: Changes to CI configuration files and scripts.
  - chore: Other changes that don't modify src or test files.
  - revert: Reverts a previous commit.

## What I discovered and learned on top of my current knowledge

- `StringBuilder` and `ConsoleKeyInfo` input combination : at least now I know a new way of processing user input alongside with `Readline()` that would not pause the user execution but sure it super hard and easy to mess things up
- How to get the user's console size and utilize it for dictating some conditions like what I did
- How to set the default value of your Properties and I learned the hard way that properties cannot be passed by reference
- `"\a"` is the `Console.Beep()` cross-platform alt
- basic understanding of Enums
- basic understanding of struct and when to use them
- basic understanding of records and its types and when to use both
- how to work with abstraction
- how to work with interfaces and use them
- how to use Random.shared
- the basics of using collection and LINQ
