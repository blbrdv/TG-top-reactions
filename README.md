# TG top reactions

Simple script for getting posts ordered by reactions count in last year.

## Why?

Because i can.

## Run

1. Set following environment variables:
 - `API_HASH` - credentials of account for this script. 
Obtained from [here](https://my.telegram.org/apps).
Example: `abcdef0123456798abdef0123456789`.
 - `API_ID` - same as above.
Example: `12345678`.
 - `CHANNEL` - username of channel you want to check.
 - `PHONE` - phone number in international format of account.
Example: `+78005553535`.
 - `LIMIT` - Limit of reactions count in message.
Example: `5`.
 - `MINUTES` - Limit in minutes datetime of messages from now. 
Example: `525600`.

2. Run script.

Result of script will be printed in this format: 
```
N  https://t.me/channelname/id
N  https://t.me/channelname/id
N  https://t.me/channelname/id
```
Where N - is reaction count in message, channel - channel name you provided, id - message id. 
