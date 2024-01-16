# Automation Execution Environment


## Building a New Automation Execution Environment

```sh
yum install ansible-builder
```

`ansible-builder` searches for `execution-environment.yml` file in the current directory

example of `execution-environment.yml` file:

```yaml
---
version: 1

build_arg_defaults:
  EE_BASE_IMAGE: registry.redhat.io/ansible-automation-platform-22/ee-minimal-rhel8:latest
  EE_BUILDER_IMAGE: registry.redhat.io/ansible-automation-platform-22/ansible-builder-rhel8:latest

ansible_config: ansible.cfg

dependencies:
  galaxy: requirements.yml
  python: requirements.txt
  system: bindep.txt
```
* `EE_BASE_IMAGE` - the base image for the execution environment (quay.io/ansible/ansible-runner:stable-2.12-latest)
* `EE_BUILDER_IMAGE` - the image used to build the execution environment (quay.io/ansible/ansible-builder:stable-2.12-latest)

requirements.yml:
```yaml
---
collections:
  - community.aws
  - community.general
  - name: redhat.insights
    version: 1.0.5
    source: https://console.redhat.com/api/automation-hub/
  - name: ansible.posix
    source: https://hub.example.com/api/galaxy/content/rh-certified/
```

requirements.txt:
```txt
sh==1.13.1
jsonschema>=3.2.0,<4.0.1
textfsm
ttp
xmltodict
dnspython
```

bindep.txt:
```txt
rsync [platform:rpm]
kubernetes-client [platform:rpm]
```

## Simple build


```sh
ansible-builder build --tag ee-demo:v1.0
```

## Interactive build

Step1. Creating the `context/` directory in the current directory.
```sh
ansible-builder create
```

```
# /home/user/demo/context
├── ansible.cfg
├── bindep.txt
├── context
│   ├── _build
│   │   ├── ansible.cfg
│   │   ├── bindep.txt
│   │   ├── requirements.txt
│   │   └── requirements.yml
│   └── Containerfile
├── execution-environment.yml
├── requirements.txt
└── requirements.yml
```

Step2. Adjusting

adjust `execution-environment.yml` file

`Containerfile` file that defines the build process

```
ARG EE_BASE_IMAGE=registry.redhat.io/ansible-automation-platform-22/ee-minimal-rhel8:latest
ARG EE_BUILDER_IMAGE=registry.redhat.io/ansible-automation-platform-22/ansible-builder-rhel8:latest

FROM $EE_BASE_IMAGE as galaxy
ARG ANSIBLE_GALAXY_CLI_COLLECTION_OPTS=
USER root

COPY my-company-ca.pem /etc/pki/ca-trust/source/anchors
RUN update-ca-trust

ADD _build/ansible.cfg ~/.ansible.cfg
...output omitted...
```

run the command to complete the build process:
```sh
podman build -f context/Containerfile -t ee-demo:v2.0 context
```
