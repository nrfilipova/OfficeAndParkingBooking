const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7014';

const PROXY_CONFIG = [
  {
    "/api":{
        "target": "https://127.0.0.1:57171/",
        "secure": false,
        "changeOrigin": true
    }
}
]