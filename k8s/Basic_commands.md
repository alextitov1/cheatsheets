#### help  

```sh
kubectl --help
kubectl create --help
```

#### Cluster info

```sh
# Print the supported API versions on the server
kubectl api-versions

# Print the supported API resources on the server
kubectl api-resources
# API-Group/API-Version - API-Group is blank for Kubernetes core resources
# KIND - the formal Kubernetes resource schema type

# Display addresses of the control plane and services
kubectl cluster-info
```

#### `get`
retrieves information about resources in the selected project
```sh
oc get clusteroperator # [-o yaml | json]
kubectl get all
kubectl get pods -o wide
kubectl get pods \
-o custom-columns=PodName:".metadata.name",\
ContainerName:"spec.containers[].name",\
```

#### `explain`
provides detailed information about the `attributes` of a given resource type
```sh
kubectl explain pods
kubectl explain pods.spec
```

#### `describe`
provides detailed information about a `given resource`
```sh
kubectl describe mysql-openshift-1-glgrp
```

#### Other commands
```sh
oc create -f pod.yaml
oc delete
```

### OC specific commands

```sh
oc login cluster-url
oc new-project myapp
oc status

```

#### oc adm

```sh
# 
oc adm top pods -A --sum