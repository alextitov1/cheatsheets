# Node controller

Node monitoring period - 5 seconds

Node monitoring Grace Period - 40 seconds (before marking a node as NotReady)


POD Eviction Timeout - 5 minutes


# Replication Controller and ReplicaSet
**Replication Controller** is an older resource that ensures a specified number of pod replicas are running. **ReplicaSet** is a newer version that provides the same functionality but with additional features like support for set-based label selectors.

## yaml example
```yaml
# replication-controller.yaml
apiVersion: v1
kind: ReplicationController
metadata:
    name: nginx-rc
    labels:
        app: myapp
        type: frontend
spec:
    template:
        metadata:
        name: myapp-pod
        labels:
            app: myapp
            type: frontend
        spec:
        containers:
            - name: nginx-container
                image: nginx
    replicas: 3
```

```yaml
# replicaset.yaml
apiVersion: apps/v1
kind: ReplicaSet
metadata:
    name: myapp-replicaset
    labels:
      app: myapp
      type: front-end
spec:
    replicas: 3
    template:
        metadata:
            name: myapp-pod
            labels:
                app: myapp
                type: front-end
        spec:
            containers:
              - name: nginx-container
                image: nginx
    selector:
        matchLabels:
            type: front-end
```

## Commands
```sh
kubectl get replicationcontroller

kubectl get replicaset
kubectl delete replicaset myapp-replicaset
kubectl replace -f replicaset.yaml
kubectl scale --replicas=5 replicaset myapp-replicaset
```


# Kube-ControllerManager
 Kube-ControllerManager is a control plane component that runs controller processes. Each controller is a separate process that watches the state of the cluster and makes or requests changes where needed.

 ```sh
 # settings 
 cat /etc/kubernetes/manifests/kube-controller-manager.yaml

 ps -aux | grep kube-controller-manager
 ```
