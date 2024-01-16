# Ansible Collections

Ansible supports collections since Ansible 2.8

RedHat recommends moving `roles`, `modules`, `plugins` and `filters` inside collections.

`namespace` - is the first part of a collection name, e.g. the namespace of the `amazon.aws` is `amazon`.

## ansible.cfg
ansible.cfg
```ini
[defaults]
collections_paths = ~/.ansible/collections:/usr/share/ansible/collections.
```

## Install collections

By default ansible-galaxy installs the collections in the first directory that the `collections_paths` directive points to

```sh
ansible-galaxy collection install community.crypto
ansible-galaxy collection install /tmp/community-dns-1.2.0.tar.gz

ansible-galaxy collection install \
  http://www.example.com/redhat-insights-1.0.5.tar.gz

ansible-galaxy collection install \
  git@github.com:ansible-collections/community.mysql.git \
  -p ~/myproject/collections/

ansible-galaxy collection install -r requirements.yml
```

### File examples

collections/requirements.yml
```yml
---
collections:
  - name: community.crypto

  - name: ansible.posix
    version: 1.2.0

  - name: /tmp/community-dns-1.2.0.tar.gz

  - name: http://www.example.com/redhat-insights-1.0.5.tar.gz

  - name: git@github.com:ansible-collections/community.mysql.git
```

### Configuring Collection Sources

By default ansible-galaxy uses https://galaxy.ansible.com to download collections.

ansible.cfg
```ini
[galaxy]
server_list = automation_hub, galaxy

[galaxy_server.automation_hub]
url=https://console.redhat.com/api/automation-hub/
auth_url=https://sso.redhat.com/auth/realms/redhat-external/protocol/openid-connect/token
token=draz...Usnx

[galaxy_server.galaxy]
url=https://galaxy.ansible.com/
```

## Create a new collection

create directory structure for a new collection
```sh
ansible-galaxy collection init mynamespace.mycollection
```

```sh
mynamespace/
└── mycollection
    ├── docs # documentation for your modules, plugins, etc
    ├── meta # isn't created by init command
    │   └── runtime.yml # 
    ├── galaxy.yml # metadata for Ansible to build and publish the collection
    ├── plugins # your modules, plugins, and filters
    │   └── README.md
    │   └── modules
    │   └── inventory
    ├── README.md # file describes your collection
    ├── roles # directory stores your roles
    ├── requirements.txt # python dependencies
    └── bindep.txt # binary dependencies e.g. rsync
```
### File examples

#### galaxy.yml
```yaml
---
namespace: mynamespace
name: mycollection
version: 1.0.0
readme: README.md
authors:
  - your name <example@domain.com>
description: Ansible modules to manage my company's custom software
license:
  - GPL-3.0-or-later

repository: https://git.example.com/training/my-collection

# The URL to any online docs
documentation: https://git.example.com/training/my-collection/tree/main/docs

# The URL to the homepage of the collection/project
homepage: https://git.example.com/training/my-collection

# The URL to the collection issue tracker
issues: https://git.example.com/training/my-collection/issues

dependencies:
  community.general: '>=1.0.0'
  ansible.posix: '>=1.0.0'
```

#### requirements.txt (Python dependencies)
```txt
botocore>=1.18.0
boto3>=1.15.0
boto>=2.49.0
```

#### bindep.txt
```txt
rsync [platform:centos-8 platform:rhel-8]
```

#### meta/runtime.yml
```yaml
---
requires_ansible: ">=2.10"
```

### Create a role in the new collection
```sh
cd mynamespace/mycollection/roles/ && ansible-galaxy init myrole
```

### Building Collections

```sh
# from inside the collection directory
ansible-galaxy collection build
```

### Testing Collections

```sh
ansible-lint
ansible-test
```

### Publishing Collections

```sh
ansible-galaxy collection publish mynamespace-mycollection-2.0.0.tar.gz
```