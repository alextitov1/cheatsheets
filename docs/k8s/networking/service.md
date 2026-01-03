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