# NerdBot-Sharp
C# Version of NerdBot



NerdBot Sharp is a Discord Bot.



## Running NerdBot

1. Have the dotnetcore runtime setup.
2. Download the release
3. Create a .env file (see below)
4. run `dotnet NerdBot-Sharp.dll`

### The `.env` File

Your .env file needs to be placed in the root of the bot's folder and **must** be called `.env`. The contents should be as follows:

```environment
DiscordToken="YOUR TOKEN GOES IN THESE QUOTEMARKS"
Prefix=!
```

The settings are:

| #### Item    | #### Description                                             |
| ------------ | ------------------------------------------------------------ |
| DiscordToken | Your Discord Bot's token, obtained from the API site.        |
| Prefix       | The prefix for all commands. It can be a string, but a single character is recommended. |



## Contributing

 NerdBot is built in C# for DotNet Core. While this can be developed in Visual Studio, VS Code or really any text editor you want, I (Ela) use JetBrains Rider because I get it free. If you are a student/affiliated with an academic organisation, you can get it free as well. More info is [here](https://www.jetbrains.com/community/education/#students). 

 Only Ela and those approved may work on the "dev" branch and only Ela may work on the "master" branch.



### Getting the code

1. Clone the Git repo. I don't really care what you use to do this.
2. Create/Checkout the branch for what you are working on. Be descriptive in the title. If you are working on quotes, call it something like "quotes". If you are fixing an issue with a command, use something like "fixing-command-<commandname>"
3. Do your code. Make it pretty etc.
4. Commit your code to your branch.
5. Create a pull request, describing the changes, who's worked on them, what they fix and what they break.
6. Wait for it to be accepted.



### Important Notes

- NerdBot builds to DotNet Core 5.05. This is because of Discord.Net.
- NerdBot uses Discord.Net for its Discord library.
- Remember to drink while coding.


