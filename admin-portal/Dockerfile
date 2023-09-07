FROM node:18-slim

# install app dependencies
COPY package.json .
COPY package-lock.json .
RUN npm install --silent --force

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY . .

EXPOSE 5173
EXPOSE 3101
