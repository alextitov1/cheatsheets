# Ingress

Ingress is a Kubernetes primitive (api: networking.k8s.io/v1, kind: Ingress) that manages external access to services within a cluster, typically HTTP/HTTPS. It acts as a reverse proxy, routing traffic from outside the cluster to services based on defined rules. Can also provide **load balancing**, **SSL termination**, and **name-based virtual hosting**.

## Ingress resource(s?)

An Ingress resource defines how to route traffic to services based on hostnames and paths.

### Service as backend
    
```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: ingress-backend-service
spec:
  backend:
    serviceName: my-service
    servicePort: 80
```

### Resource rules

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: ingress-rules-example
spec:
   rules:
    - http:
        paths:
          - path: /foo
            backend:
              serviceName: foo-service
              servicePort: 80
          - path: /bar
            backend:
              serviceName: bar-service
              servicePort: 80
```

### Domain-based routing

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
    name: ingress-host-example
spec:
    rules:
    - host: foo.example.com
      http:
        paths:
         - backend:
             serviceName: foo-service
             servicePort: 80
    - host: bar.example.com
      http:
        paths:
          - backend:
             serviceName: bar-service
             servicePort: 80
```

## Operates difficulties

## Nginx Ingress deployment example


## Problems

- Ingress rules can become complex and hard to manage as the number of services grows.
- Debugging ingress issues can be challenging due to the multiple layers of abstraction.
- Not all ingress controllers support the same features, leading to potential compatibility issues.
