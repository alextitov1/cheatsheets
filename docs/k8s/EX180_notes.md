

## Examining Cluster Metrics

### oc adm

```sh
oc adm top pods -A --sum

oc adm must-gather --dest-dir /home/student/must-gather

oc adm inspect clusteroperator/openshift-apiserver \
clusteroperator/kube-apiserver


oc adm inspect clusteroperator/openshift-apiserver --since 10m

oc adm top pods -A --sum

oc adm top pods etcd-master01 -n openshift-etcd --containers
```
## Query Cluster Events and Alerts


```sh
oc debug

oc debug job/test --as-user=10000

oc debug node/node-name
```


# Run Applications as Containers and Pods

oc run RESOURCE/NAME --image IMAGE [options]

kubectl run web-server --image registry.access.redhat.com/ubi8/httpd-24

```sh
# -- arguments
kubectl run RESOURCE/NAME --image IMAGE -- arg1 arg2 ... argN
```

```sh
oc exec RESOURCE/NAME -- COMMAND [args...] [options]

oc exec my-app -- date # exec in the first container of the pod
kubectl exec my-app -c ruby-container -- date
oc attach my-app -it
```

## Node debug

ssh to a node or

create a debug pod

```sh
oc debug node/node-name
chroot /host
```

### cri debug

```sh
# get pod id
crictl pods --name master01-debug

# get container name from pod id
crictl ps -p cb066ee76b598 -o json | jq -r .containers[0].metadata.name

# get container id
CID=$(crictl ps --name container-00 -o json | jq -r .containers[0].id)

# get PID of the container
crictl inspect $CID | grep pid

# list namespaces

lsns -p pid

# enter the container namespace
nsenter -t PID -p -r ps -ef
# -t PID - target PID
# -p - enter PID namespace
# -r -  set the top-level directory
```


# Common Resource Types

## Templates
Templates (RHOCP feature) - a yaml manifest that contains parameterized definitions of one or more resources. Processed by the `oc process` command, which replaces value and generates resource definitions. The resulting resource definitions can be applied to a cluster using the `oc apply` command.
```sh
# process and generate resource definitions from a file.
oc process -f mysql-template.yaml -o yaml

# display the parameters defined in a template
oc process -f mysql-template.yaml --parameters
```

You also use templates with the `oc new-app` command
```sh
oc new-app --template=mysql-persistent
```

## Pod
the smallest compute unit that can be defined.

## DeploymentConfig
*Deployment configurations* define the specification of a pod. They manage pods by creating *replication controllers*.

## Deployment
Similar to deployment configurations, *deployments* define the intended state of a replica set.

## ReplicaSet
*Replica sets* define a configurable number of pods that match a specification.

## Project
A *project* is a Kubernetes namespace with additional annotations, and is the primary method for managing access to resources in a cluster.

## Service
an object for internal pod-to-pod communication. Application send requests to a service and and port.

## PersistentVolume Claim(PVC)

## Secrets

# Resource Management

Imperative - instructs what the system does

Declarative - defines the state that the cluster attempts to match.


