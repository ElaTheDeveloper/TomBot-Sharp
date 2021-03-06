# Contributing

 NerdBot is built in C# for DotNet Core. While this can be developed in Visual Studio, VS Code or really any text editor you want, I (Ela) use JetBrains Rider because I get it free. If you are a student/affiliated with an academic organisation, you can get it free as well. More info is [here](https://www.jetbrains.com/community/education/#students). 
 
 Only Ela and those approved may work on the "dev" branch and only Ela may work on the "master" branch.

# We Now Use FLow. Ignore the Getting the code bit.
[Follow this now](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)


## Getting the code

1. Clone the Git repo. I don't really care what you use to do this.
2. Create/Checkout the branch for what you are working on. Be descriptive in the title. If you are working on quotes, call it something like "quotes". If you are fixing an issue with a command, use something like "fixing-command-<commandname>" **ENSURE YOU HAVE YOUR USERNAME IN THE BRANCH NAME! Your branch will be deleted otherwise!**. Example: `elathedeveloper-commandfix`
3. Do your code. Make it pretty etc.
4. Commit your code to your branch.
5. Create a pull request, describing the changes, who's worked on them, what they fix and what they break.
6. Wait for it to be accepted.



## Important Notes

- NerdBot builds to DotNet Core 5.0. This is because of Discord.Net.
- NerdBot uses Discord.Net for its Discord library.
- Remember to drink while coding.

## Versioning
NerdBot versions are in the format of `YEAR.MONTH.DAY.PATCH`. For example, the fourtheenth patch released on July 18th 2020 would recieve the version `2020.7.18.14`.
