FROM node:20-alpine AS builder

WORKDIR /app

COPY package*.json ./

RUN npm install


FROM node:20-alpine AS development

WORKDIR /app

COPY --from=builder /app/node_modules ./node_modules

COPY . .

EXPOSE 4000

# CMD ["npm", "run", "dev"]
CMD ["npm", "start"]