# NerdBot-Sharp
C# Version of NerdBot
NerdBot Sharp is a Discord Bot.
<br />
<a href='https://ko-fi.com/elathedeveloper' target='_blank'><img height='35' style='border:0px;height:46px;' src='https://az743702.vo.msecnd.net/cdn/kofi3.png?v=0' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>
<a href="https://www.patreon.com/bePatron?u=42078320" style='border:"1px solid #FF424D";border-radius:10px;'><img height='35' style='border:"1px solid #FF424D";border-radius:10px;height:46px;' src='https://cloakandmeeple.files.wordpress.com/2017/06/become_a_patron_button3x.png' border='0' alt='Become a Patron'/></a>

# Support Development
If you wish to support development, you can help by sponsoring. There are two main ways, through Ko-Fi and Patreon.
## Ko-Fi
Ko-Fi allows for one off donations, with as little as £1. You can find Ela's Ko-Fi page linked in the sponsorship section of GitHub.
## Patreon
If you want to help cover the costs of hosting the bot, you can set up a monthly donation through Patreon. Tiers start at £1.

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


