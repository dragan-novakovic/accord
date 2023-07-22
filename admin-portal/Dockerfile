FROM node:18-slim


WORKDIR /usr/app
COPY ./ /usr/app


EXPOSE 5173

RUN npm i --force
CMD [ "npm", "run", "dev" ] 