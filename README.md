# TG top reactions

Simple script for getting posts ordered by reactions count in last year.

## Why?

Because i can.

## Run

1. Write following arguments:
 - `-h`, `--hash` - credentials of account for this script. 
Obtained from [here](https://my.telegram.org/apps).
Example: `abcdef0123456798abdef0123456789`.
 - `-i`, `--id` - same as above.
Example: `12345678`.
 - `-c`, `--channel` - username of channel you want to check.
 - `-p`, `--phone` - phone number in international format of account.
Example: `+78005553535`.
 - `-r`, `--reactions` - Limit of reactions count in message.
Example: `5`.
 - `-t`, `--period` - Period for which messages are parsed. 
Example: `2M3d1h`.

2. Run script.

Result of script will be printed in this format: 
```
N  https://t.me/channelname/id
N  https://t.me/channelname/id
N  https://t.me/channelname/id
```
Where N - is reaction count in message, channel - channel name you provided, id - message id. 
