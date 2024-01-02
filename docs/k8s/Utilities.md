
# kubctl
## Install kubectl on linux

```sh
curl -LO "https://dl.k8s.io/release/$(curl -L \
  -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"

curl -LO "https://dl.k8s.io/$(curl -L \
-s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl.sha256"

sudo install -o root -g root -m 0755 kubectl \
  /usr/local/bin/kubectl

kubectl version --client
```

## yq

```sh
oc get pods -o yaml | yq r - 'items[0].status.podIP'
r - read specified path
"-" - stdin
```

## lsns

list namespaces

```sh
lsns -p pid
```

## ldd
print shared object dependencies

```sh
ldd /bin/kubectl
```