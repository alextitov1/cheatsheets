# Compose

## Compose spec

https://github.com/compose-spec/compose-spec/blob/master/spec.md

## Basic commands
```sh
podman-compose up
# Options:
# -d, --detach: Start containers in the background.
# --force-recreate: Re-create containers on start.
# -V, --renew-anon-volumes: Re-create anonymous volumes.
# --remove-orphans: Remove containers that do not correspond to services that are defined in the current Compose file.

podman-compose stop/dow

podman-compose logs -n -f
```

## Podman Pods??

`podman generate kube` - generate a Kubernetes YAML file from a Podman pod definition

`podman play kube` - create a pod from a Kubernetes YAML file


## The Compose File

* `version` (deprecated): Specifies the Compose version used.
* `services`: Defines the containers used.
* `networks`: Defines the networks used by the containers.
* `volumes`: Specifies the volumes used by the containers.
* `configs`: Specifies the configurations used by the containers.
* `secrets`: Defines the secrets used by the containers.

## Examples

compose.yaml
```yaml
services:
  frontend:
    image: quay.io/example/frontend
    networks:
      - app-net
    ports:
      - "8082:8080"
  backend:
    image: quay.io/example/backend
    networks:
      - app-net
      - db-net
    depends_on:
     - db
  db:
    image: registry.redhat.io/rhel8/postgresql-13
    environment:
      POSTGRESQL_ADMIN_PASSWORD: redhat
    networks:
      - db-net
    volumes:
      - db-vol:/var/lib/postgresql/data

networks:
  app-net: {}
  db-net: {}

volume:
  db-vol: {}

```

## Installing Podman Compose

```sh
pip3 install podman-compose
```

# Links

[Podman Compose Vs Docker Compose](https://www.redhat.com/sysadmin/podman-compose-docker-compose)
