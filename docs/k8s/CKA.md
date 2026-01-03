# CKA Curriculum

## 10% Storage

- implement storage classes and dynamic volume provisioning
- Configure volume types, access modes and reclaim policies
- Manage persistent volumes and persistent volume claims

## 15% Workloads and Scheduling

- Understand application deployment and how to perform rolling update and rollbacks
- Use ConfigMaps and Secrets to configure applications
- Configure workload autoscaling
- Understand the primitives used to create robust, self-healing, application deployments
- Configure Pod admission and scheduling (limits, node affinity, etc.)

## 20% Servicing and Networking

- Understand connectivity between Pods
- Define and enforce Network Policies
- Use ClusterIP, NodePort, LoadBalancer service types and endpoints
- Use the Gateway API to manage ingress traffic
- Know how to use Ingress controllers and Ingress resources
- Understand and use CoreDNS

## 30% Troubleshooting

- [x] Troubleshoot cluster and nodes
- [x] Troubleshoot cluster components
- [ ] Monitor cluster and application resource usage
- [x] Manage and evaluate container output streams
- [x] Troubleshoot service and networking

## 25% Cluster Architecture, Installation and Configuration

- Manage role based access control (RBAC)
- Prepare underlying infrastructure for installing a Kubernetes cluster
- Create and manage Kubernetes clusters using kubeadm
- Manage the lifecycle of Kubernetes clusters
- Implement and configure a highly available control plane
- Use Helm and Kustomize to install cluster components
- Understand extension interfaces (CNI, CSI, CRI, etc)


# MOCK - 1 

q.7

Q: Expose the hr-web-app created in the previous task as a service named hr-web-app-service, accessible on port 30082 on the nodes of the cluster.
The web application listens on port 8080.

A: Run the command: kubectl expose deployment hr-web-app --type=NodePort --port=8080 --name=hr-web-app-service --dry-run=client -o yaml > hr-web-app-service.yaml to generate a service definition file.
Now, in generated service definition file add the nodePort field with the given port number under the ports section and create a service.

q. 10 - VPA

Q: Deploy a Vertical Pod Autoscaler (VPA) with name analytics-vpa for the deployment named analytics-deployment in the default namespace.
The VPA should automatically adjust the CPU and memory requests of the pods to optimize resource utilization. Ensure that the VPA operates in Auto mode, allowing it to evict and recreate pods with updated resource requests as needed.

A:
```sh
kubectl create -n default -f - <<EOF
apiVersion: autoscaling.k8s.io/v1
kind: VerticalPodAutoscaler
metadata:
  name: analytics-vpa
  namespace: default
spec:
  targetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: analytics-deployment
  updatePolicy:
    updateMode: "Auto"
EOF
```

# MOCK - 2

q. 8

Q: Create a Horizontal Pod Autoscaler with name backend-hpa for the deployment named backend-deployment in the backend namespace with the webapp-hpa.yaml file located under the root folder.
Ensure that the HPA scales the deployment based on memory utilization, maintaining an average memory usage of 65% across all pods.
Configure the HPA with a minimum of 3 replicas and a maximum of 15.

A:
```yaml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: backend-hpa
  namespace: backend
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: backend-deployment
  minReplicas: 3
  maxReplicas: 15
  metrics:
  - type: Resource
    resource:
      name: memory
      target:
        type: Utilization
        averageUtilization: 65
```

q. 9

Q: Task

Modify the existing web-gateway on cka5673 namespace to handle HTTPS traffic on port 443 for kodekloud.com, using a TLS certificate stored in a secret named kodekloud-tls.

A:

```sh
controlplane ~ ➜  kubectl get gateway web-gateway -n cka5673 -o yaml
apiVersion: gateway.networking.k8s.io/v1
kind: Gateway
metadata:
  name: web-gateway
  namespace: cka5673
  resourceVersion: "21919"
  uid: a1d0e35d-5126-4000-88ec-f440941eed75
spec:
  gatewayClassName: kodekloud
  listeners:
  - allowedRoutes:
      namespaces:
        from: Same
    name: https
    port: 80
    protocol: HTTP
```

```yaml
# web-gateway.yaml
apiVersion: gateway.networking.k8s.io/v1
kind: Gateway
metadata:
  name: web-gateway
  namespace: cka5673
spec:
  gatewayClassName: kodekloud
  listeners:
    - name: https
      protocol: HTTPS
      port: 443
      hostname: kodekloud.com
      tls:
        certificateRefs:
          - name: kodekloud-tls
```

q. 10

Q: On the cluster, the team has installed multiple helm charts on a different namespace. By mistake, those deployed resources include one of the vulnerable images called kodekloud/webapp-color:v1. Find out the release name and uninstall it.

A:
```sh
helm ls -A

kubectl get deploy -n <NAMESPACE> <DEPLOYMENT-NAME> -o json | jq -r '.spec.template.spec.containers[].image'

helm uninstall <RELEASE-NAME> -n <NAMESPACE> 
```

q. 11

Q: You are requested to create a NetworkPolicy to allow traffic from frontend apps located in the frontend namespace, to backend apps located in the backend namespace, but not from the databases in the databases namespace. There are three policies available in the /root folder. Apply the most restrictive policy from the provided YAML files to achieve the desired result. Do not delete any existing policies.

A: Read through all provided NetworkPolicy YAML files carefully.


## from medium.com

Q: Generate a Helm template and save it to a file using the helm template command. Then install the Helm chart with some changes to the Helm values. Both tasks were in a specific namespace, and a specific chart version was mentioned

Q: A deployment with three replicas had some pods in a pending state because the resource requests of containers exceeded the resources available on the node. Check the node’s CPU and memory, then divide them equally among the containers — keeping some overhead for system components and buffer — so that the deployment schedules all three replicas without any being pending.


# Killer.sh

Q: Check all available Pods in the Namespace project-c13 and find the names of those that would probably be terminated first if the nodes run out of resources (cpu or memory).