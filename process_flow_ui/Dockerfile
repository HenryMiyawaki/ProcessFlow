FROM node:20-alpine3.17

WORKDIR /app/

COPY ./app/package.json ./

RUN npm i npm@latest -g
RUN npm install
RUN npm install -g @angular/cli

COPY ./app ./

EXPOSE 4200

CMD ["ng", "serve", "--host", "0.0.0.0"]