# MarketSignals
**An application which helps in crypto speculations.**

Currently focused on Windows desktop app. In future web site will appear.

## Features

- Watch constantly Twitter to see if any important tweets have appeared.
- Be informed when a youtuber posts new video.
- Get notifications when indicators triggers or certain market structure appear.

## Contribution
Application uses services from Youtube, Twitter and Taapi. If you want to use or develop an application, a file with credentials will be needed.
App expects to have Credentials.json file in a same directory as .exe file. When developing simply add the .json file to SignalSources.Common project.
The file should have this structure:
```json
{
  "TwitterSecrets": {
    "consumerKey": "XXX",
    "consumerSecret": "XXX",
    "accessToken": "XXX",
    "accessSecret": "XXX"
  },
  "YoutubeSecrets": {
    "apiKey": "XXX"
  },
  "TaapiSecrets": {
    "secret": "XXX"
  }
}
```
