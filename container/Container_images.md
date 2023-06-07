# Container images

## Basic commands

### Inspect
```sh
podman images --format="{{.Names}}\t{{.Size}}"
podman image inspect imageID
podman image tree hello-server:bad
```

### Search images in registry

```sh
podman search nginx
```

### Build image

```sh
podman build -t localhost/my-container -f Containerfile.my-container

podman build --squash -t localhost/squashed .
podman build --squash-all -t localhost/squashed .
```

### Remove all images 
```sh
podman rmi --all
# or
podman image rm --all
```

Removes `dangling` images. (without tags and that aren't referenced by other images)
```sh
podman image prune
```

With option `--all` removes all unused images
```sh
podman image prune -af
```

### Save/load images to/from tarball
```sh
podman save --output images.tar \
docker.io/library/redis \
docker.io/library/mysql

podman load --input images.tar
```

### Login to registry

```sh
podman login registry.redhat.io
```

Podman stores the credentials in the `${XDG_RUNTIME_DIR}/containers/auth.json` file

<details>
<summary>auth.json example</summary>

```
[user@host ~]$ cat ${XDG_RUNTIME_DIR}/containers/auth.json
{
	"auths": {
		"registry.redhat.io": {
			"auth": "dXNlcjpodW50ZXIy"
		}
	}
}
[user@host ~]$ echo -n dXNlcjpodW50ZXIy | base64 -d
user:hunter2
```
</details>


## Container image naming

>[\<image repository>/\<namespace>/]\<image name>[:\<tag>]

MAJOR.MINOR.PATCH meaning:

* MAJOR: backward incompatible changes
* MINOR: backward compatible changes
* PATCH: bug fixes

[more about tags](https://redhat-connect.gitbook.io/catalog-help/container-images/container-image-details/image-tags-and-versions)


# Container Registry

## Podman registry config

podman registries config file location 

```sh
grep ^[^#] /etc/containers/registries.conf
``` 

## RedHat registries

```sh
registry.access.redhat.com # requires no authentication
registry.redhat.io # requires authentication
registry.connect.redhat.com # requires authentication third-party products
quay.io # redhat public registry
```

## Useful images

[RehHat UBI images](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html-single/building_running_and_managing_containers/index#con_understanding-the-ubi-standard-images_assembly_types-of-container-images)

UBI - universal base images

* **Standard**: This is the primary UBI, which includes DNF, systemd, and utilities such as gzip and tar.

* **Init**: Simplifies running multiple applications within a single container by managing them with systemd.

* **Minimal**: This image is smaller than the init image and still provides nice-to-have features. This image uses the microdnf minimal package manager instead of the full-sized version of DNF.

* **Micro**: This is the smallest available UBI because it only includes the bare minimum number of packages. For example, this image does not include a package manager.

```sh
registry.access.redhat.com/ubi9 # RedHat Universal Base Image
registry.access.redhat.com/ubi9/python-39 # Python 3.9 on UBI9
```

## Run your own registry

Quay container registry - container image
```
 podman pull registry.redhat.io/quay/quay-rhel8
```

Nexus - the artifact repository
```
podman pull dockette/nexus:latest
```

# Build

## Basic commands

```sh
podman build -t localhost/not-squashed .

# squash CoW layers
podman build --squash -t localhost/squashed .
podman build --squash-all -t localhost/squashed .
```

## Containerfile Instructions

> Containerfiles use a small domain-specific language (DSL)

* `FROM` 
```Docker
FROM registry.access.redhat.com/ubi8/ubi-minimal:latest
```
* `ARG` (Defines build-time variables, typically to make a customizable container build)
* `ENV` (You can declare multiple ENV instructions within the Containerfile)

```Docker

ARG VERSION="1.16.8" BIN_DIR=/usr/local/bin/

ENV VERSION=${VERSION} \
    BIN_DIR=${BIN_DIR}

RUN curl "https://dl.example.io/${VERSION}/example-linux-amd64" \
        -o ${BIN_DIR}/example

```
* `WORKDIR` (Sets the working directory for subsequent instructions)

```Docker
WORKDIR /opt/app-root/src
```

* `COPY` and `ADD`
```Docker
COPY --chown=1001:0 app.js /opt/app-root/src/
ADD https://example-linux-amd64 /usr/local/bin/example

# The ADD instruction adds the following functionality: 
# * Copying files from URLs.
# * Unpacking tar archives in the destination image.
# Because the ADD instruction adds functionality that might not be obvious, developers tend to prefer the COPY instruction for copying local files into the container image.
```
* `RUN` (Executes a command and creates a new layer)
```Docker
RUN yum install -y httpd
```

* `USER` (Instructions that follow the USER instruction run as this user, including the CMD instruction.)
```Docker
USER 1001
```
* `LABEL` (Adds a key-value pair to the metadata of the image for organization and image selection)
```Docker
LABEL name="example" \
	  version="1.0" \
	  release="1" \
	  summary="Example application" \
	  description="Example application for demonstrating Containerfiles"
```

* `EXPOSE` (This instruction does not bind the port on the host and is for documentation purposes)
```Docker
EXPOSE 8080
```

* `VOLUME` (A data volume is a specially-designated directory within one or more containers that bypasses the Union File System.)
```Docker
VOLUME /var/lib/mysql
```
* `ENTRYPOINT` (Sets the executable to run when the container is started) 
```Docker
ENTRYPOINT ["executable", "param1", ... "paramN"]
```
* `CMD` (Runs a command when the container is started. This command is passed to the executable defined by ENTRYPOINT. Base images define a default ENTRYPOINT, which is usually a shell executable, such as Bash.)
```Docker
CMD ["echo", "Hello", "Red Hat"]
```
> Neither ENTRYPOINT nor CMD run when building a container image. Podman executes them when you start a container from the image.

## Multistage Builds

```Docker
# First stage
FROM registry.access.redhat.com/ubi8/nodejs-14:1 as builder
COPY ./ /opt/app-root/src/
RUN npm install
RUN npm run build

# Second stage
FROM registry.access.redhat.com/ubi8/nginx-120
COPY --from=builder /opt/app-root/src/ /usr/share/nginx/html
```

# Utility

`scopeo` is a command line utility that allows you to inspect and manage container images.

```sh
skopeo copy --dest-tls-verify=false \
  docker://${RHOCP_REGISTRY}/default/python:3.9-ubi8 \
  docker://registry.ocp4.example.com:8443/developer/python:3.9-ubi8
```

buildah - build container images from Dockerfiles
