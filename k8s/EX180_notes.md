

## Examining Cluster Metrics

oc adm top pods -A --sum

oc adm must-gather --dest-dir /home/student/must-gather

oc adm inspect clusteroperator/openshift-apiserver \
clusteroperator/kube-apiserver


oc adm inspect clusteroperator/openshift-apiserver --since 10m

oc adm top pods -A --sum

oc adm top pods etcd-master01 -n openshift-etcd --containers

## Query Cluster Events and Alerts

oc get events -n openshift-image-registry

oc cluster-info

oc get nodes
oc get node master01 -o json | jq '.status.conditions'


oc logs pod-name -c container-name

oc debug

oc debug job/test --as-user=10000

oc debug node/node-name

oc get all -n openshift-monitoring --show-kind

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
```

## Logs
Container logs are the standard output (stdout) and standard error (stderr) output of a container. 

oc logs postgresql-1-jw89j --tail=10

oc attach my-app -it


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
