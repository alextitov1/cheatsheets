NEXT: 03.17 - Resource requirements and limits

# Key Concepts

* **Master Node**: Controls the Kubernetes cluster, managing the **API server**, **scheduler**, and **controller manager**.
* **Worker Node**: Runs the applications and workloads, containing the **kubelet**, **kube-proxy** and **container runtime**.
* **Etcd**: Key-value store for all cluster data, used by the **API server**.
* **Kube-scheduler**: Assigns pods to nodes based on resource availability and constraints.
* **Controllers**:
    - **Node Controller**: Monitors the status of nodes.
    - **Replication Controller**: Ensures the desired number of pod replicas are running.
    - **Endpoints Controller**: Manages the endpoints for services.
    - **Service Account & Token Controllers**: Create default service accounts and tokens for new namespaces.
* **Api-server**: The front-end for the Kubernetes control plane, handling REST requests and updates to etcd.
* **Container Runtime**: Software responsible for running containers, such as Docker or containerd.
* **Kubelet**: An agent that runs on each node, ensuring containers are running in pods.
* **Kube-proxy**: Manages network rules for pod communication, enabling service discovery and load balancing.


# Pods

Pod is the smallest deployable unit in Kubernetes.

```sh
kubectl run nginx --image=nginx --restart=Never
```

```yaml
# pod-definition.yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
  labels:
    app: nginx
spec:
  containers:
  - name: nginx-container
    image: nginx
    ports:
    - containerPort: 80
```

```sh
kubectl apply -f pod-definition.yaml
kubectl get pods
```

# Deployments
```sh
kubectl create deployment --image=nginx nginx --dry-run=client -o yaml
```

# Services

**Service** is an abstraction that defines a logical set of pods and a policy by which to access them.

Service types:
- **ClusterIP**: Exposes the service on a cluster-internal IP.
- **NodePort**: Exposes the service on each node's IP at a static port.
- **LoadBalancer**: Exposes the service externally using a cloud provider's load balancer

```yaml
# node-port-definition.yaml
apiVersion: v1
kind: Service
metadata:
    name: nginx-service
spec:
    type: NodePort
    ports:
    - port: 80  # Service port (within the cluster)
      targetPort: 80  # Port on the pod
      nodePort: 30080  # Node port (external access)
    selector:
        app: nginx  # Select pods with this label
        type: frontend  # Additional label for selection
```

```yaml
# cluster-ip-definition.yaml
apiVersion: v1
kind: Service
metadata:
    name: nginx-service
spec:
    type: ClusterIP # if not specified, defaults to ClusterIP
    ports:
    - port: 80  # Service port (within the cluster)
      targetPort: 80  # Port on the pod
    selector:
        app: nginx  # Select pods with this label
        type: frontend  # Additional label for selection
```

```yaml
# load-balancer-definition.yaml
apiVersion: v1
kind: Service
metadata:
    name: nginx-service
spec:
    type: LoadBalancer  # Exposes the service externally using a cloud provider's load balancer
    ports:
    - port: 80  # Service port (within the cluster)
      targetPort: 80  # Port on the pod
      nodePort: 30080  # Node port (external access)
```

# Labels and Selectors and Annotations

Labels - used to organize and select resources in Kubernetes.

Annotations - used to store additional metadata about resources.

```sh
kubectl get pods --selector app=nginx

kubectl get all --selector app=nginx,type=frontend

```

# Taints and Tolerations

**Taint** is a node property that prevents pods from being scheduled.

**Toleration** is a pod property that allows it to be scheduled on nodes with specific taints.


```sh
kubectl taint node node1 key=value:NoSchedule{PreferNoSchedule,NoExecute}

#untaint
kubectl taint nodes controlplane node-role.kubernetes.io/control-plane:NoSchedule-
```

```yaml
# pod-with-toleration.yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
spec:
  containers:
  - name: nginx-container
    image: nginx
  tolerations:
  - key: "key"
    operator: "Equal"
    value: "value"
    effect: "NoSchedule"
```

# Node Selectors and Affinity

```yaml
# pod-with-node-selector.yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
spec:
  containers:
  - name: nginx-container
    image: nginx
  nodeSelector:
    disktype: ssd  # Node label to select
```

```yaml
# pod-with-affinity.yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
spec:
  containers:
  - name: nginx-container
    image: nginx
  affinity:
    nodeAffinity:
      requiredDuringSchedulingIgnoredDuringExecution:
        nodeSelectorTerms:
        - matchExpressions:
          - key: disktype
            operator: In
            values:
            - ssd  # Node label to select
```


# Cli Commands

```sh
# Create an NGINX Pod
kubectl run nginx --image=nginx

# Generate POD Manifest YAML file (-o yaml). Don't create it(--dry-run)
kubectl run nginx --image=nginx --dry-run=client -o yaml

# Create a deployment
kubectl create deployment --image=nginx nginx

# Generate Deployment YAML file (-o yaml). Don't create it(--dry-run)
kubectl create deployment --image=nginx nginx --dry-run=client -o yaml

# Generate Deployment YAML file (-o yaml). Don’t create it(–dry-run) and save it to a file.
kubectl create deployment --image=nginx nginx --dry-run=client -o yaml > nginx-deployment.yaml

# Make necessary changes to the file (for example, adding more replicas) and then create the deployment.
kubectl create -f nginx-deployment.yaml

specify the --replicas option to create a deployment with 4 replicas.

kubectl create deployment --image=nginx nginx --replicas=4 --dry-run=client -o yaml > nginx-deployment.yaml

# Set a label on a node
kubectl label node node01 color=blue
```