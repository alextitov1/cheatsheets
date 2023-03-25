FROM debian:buster-slim

RUN set -ex && \
    apt-get update && \
    apt-get install -y nginx && \
    rm -rf /var/lib/apt/lists/*

ADD . /etc/nginx/

EXPOSE 80
ENTRYPOINT nginx -g 'daemon off;'
