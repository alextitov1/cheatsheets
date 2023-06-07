# OpenShift

>A **project** is a RHOCP `resource` which is similar to the **namespace** Kubernetes resource

> `kubectl` utility can manage a RHOCP cluster

## Get help

```sh
oc explain deployment.spec.template.spec.containers.env
```

## OpenShift CLI

```sh
oc login https://api.ocp4.example.com:6443
oc get pod
oc create -f pod.yaml
oc delete
oc logs react-uipodman pod
oc explain pod.metadata.name
```
## Label Kubernetes Objects

Labels are key-value pairs that you define in the object.

```yaml
kind: Pod
apiVersion: v1
metadata:
  name: example-pod
  labels:
    app: example-pod
    group: developerspodman pod
```
```sh
oc get pod --selector group=developers
```
## Pods

A **pod** represents a group of one or multiple containers that share resources, such as a network interface or file system

### Create Pods declaratively 

```yaml
kind: Pod
apiVersion: v1
metadata:
  name: example-pod
  namespace: example-project
spec:
  containers:
  - name: example-container
    image: quay.io/example/awesome-container
    ports:
    - containerPort: 8080
    env:
    - name: GREETING
      value: "Hello from the awesome container"
```

### Create Pods imperatively

```sh
oc run example-pod \ # 1
  --image=quay.io/example/awesome-container \ # 2
  --env GREETING='Hello from the awesome container' \ # 3
  --port=8080 # 4
  # -o yaml # 5
# 1 The pod .metadata.name definition.
# 2 The image used for the single container in this pod.
# 3 The environment variable for the single container in this pod.
# 4 The port metadata definition.
# 5 The -o yaml option prints the YAML definition of the pod to the terminal.
```
## Services

To configure pod-to-pod communication use a Service object.

The default service type is **ClusterIP**, which means the service is used for pod-to-pod routing within the cluster.Other service types e.g. **LoadBalancer** service.

### Create a Service declaratively

```yaml
apiVersion: v1
kind: Service
metadata:
  name: backend
spec:
  ports:
  - port: 8080 # 1
    protocol: TCP
    targetPort: 8080 # 2
  selector: # 3
    app: backend-app

# 1 Service port. This is the port on which the service listens.
# 2 Target port. This is the pod port to which the service routes requests. This port corresponds to the containerPort value in the pod definition.
# 3 The selector configures which pods to target. In this case, the service routes to any pods that contain the app=backend-app label.
```
### Create a Service imperatively

```sh
oc expose pod backend-app \
  --port=8080 \
  --targetPort=8080 \
  --name=backend-app
```

### 76767

bare pod

Deployment

ReplicaSet

StatefulSet

## Multi-pod Applications example

```sh
oc create deployment gitea-postgres --port 5432 -o yaml \
  --image=registry.ocp4.example.com:8443/rhel9/postgresql-13:1 \
  --dry-run=client > postgres.yaml

oc create -f postgres.yaml

# Expose the PostgreSQL database on the gitea-postgres hostname
oc expose deployment gitea-postgres
oc get svc

# Expose the application within the RHOCP cluster
oc expose deployment gitea
oc expose service gitea

oc get route
```
