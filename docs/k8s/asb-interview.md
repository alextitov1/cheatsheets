# My introduction
- system engineers background, worked for various companies in different roles.
- 3 years in ASB and last 2 in ECP squad.
- My role is to maintain and support cloud control planes of AWS and Azure. ESLZ

- Achievements
    - Complex pipelines for managing Azure Policy
    - Automate Container image pipelines


# K8S basic components
1. **API Server**: Acts as the control plane's front end, handling RESTful requests and coordinating all cluster operations.
2. **Etcd**: A distributed key-value store that stores all cluster data, ensuring consistency and reliability.
3. **Controller Manager**: Runs controllers that handle routine tasks like node management, replication, and endpoint updates.
4. **Scheduler**: Assigns pods to nodes based on resource availability and constraints.
5. **Kubelet**: An agent running on each node, ensuring containers are running as defined in the pod specifications.
6. **Kube Proxy**: Manages network rules and load balancing to enable communication between services and pods.
7. **Container Runtime**: Executes containers (e.g., Docker, containerd) and manages their lifecycle.

# K8S basic abstractions

1. **Pod**: The smallest deployable unit, representing a single instance of a running process in the cluster. 
   - **Multi-container Pod**: A pod that contains multiple containers, which can share storage and network resources.
   - **Init Container**: A special type of container that runs before the main containers in a pod, used for initialization tasks.
   - **Sidecar Container**: A container that runs alongside the main container, providing additional functionality (e.g., logging, monitoring).

How to make a pod run on a specific node: 
   - Use **nodeSelector**: A field in the pod specification that specifies the node labels the pod should match.
   - Use **nodeAffinity**: A more flexible way to specify node selection criteria, allowing for complex rules.
   - Use **taints and tolerations**: Taints prevent pods from being scheduled on nodes unless they have matching tolerations.

   - **CrashLoopBackOff**: A state indicating that a pod is repeatedly crashing and restarting. This can be caused by misconfigurations, resource limits, or application errors.
    - **Debugging**: Check logs using `kubectl logs <pod-name>`, describe the pod with `kubectl describe pod <pod-name>`, and check resource limits in the pod spec.
    - **Common Causes**: Misconfigurations, resource limits, or application errors can lead to this state.

2. **ReplicaSet**: Ensures a specified number of pod replicas are running at any given time, often used by deployments.
   - **Label Selector**: A query that identifies a set of pods based on their labels, used by ReplicaSets to manage pods.
   - **Rolling Update**: A deployment strategy that gradually replaces old pods with new ones, ensuring zero downtime.

3. **Namespace**: A virtual cluster within a physical cluster, providing a way to divide resources and manage access.

4. **Service**: An abstraction that defines a logical set of pods and a policy to access them, enabling load balancing and service discovery.
   - **ClusterIP**: The default service type, exposing the service on a cluster-internal IP.
   - **NodePort**: Exposes the service on each node's IP at a static port, allowing external access.

5. **Deployment**: A higher-level abstraction that manages the lifecycle of pods, ensuring the desired number of replicas are running and handling updates.
   - **ReplicaSet**: Ensures a specified number of pod replicas are running at any given time, often used by deployments.
    - **Rolling Update**: A deployment strategy that gradually replaces old pods with new ones, ensuring zero downtime.

6. **StatefulSet**: Manages stateful applications, providing unique network identities and stable storage for each pod.

7. **DaemonSet**: Ensures that a copy of a pod runs on all (or some) nodes in the cluster, often used for logging or monitoring agents.

# Roles

**RoleBinding**: Grants permissions to users or groups within a specific namespace, allowing them to perform actions on resources in that namespace.

**ClusterRoleBinding**: Grants permissions to users or groups across the entire cluster, allowing them to perform actions on resources in all namespaces.

**Workload Identity Federation**: A feature that allows Kubernetes workloads to authenticate to external services using their Kubernetes service account, enabling secure access to cloud resources without managing credentials.

# Mesh istio
1. **Istio**: A service mesh that provides traffic management, security, and observability for microservices.
   - **Sidecar Proxy**: A component of Istio that intercepts traffic to and from services, enabling features like load balancing and security.
   - **Envoy**: The default sidecar proxy used by Istio, providing advanced traffic management capabilities.
   - **Traffic Management**: Istio allows fine-grained control over traffic routing, enabling canary releases, A/B testing, and fault injection.

# Random Question
1. Deployment
2. DaemonSet
3. StatefulSet

RoleBinding vs ClusterRoleBinding

Workload Idnentity Federation work for Pods

How to run a pod on a pecific node

Pod stuck in a crashLoopBackoff state

Azure Policy and Gate Keeper