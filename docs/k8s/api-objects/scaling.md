````markdown
# HPA (Horizontal Pod Autoscaler) 

## HPA manual

```sh
kubectl scale deployment nginx --replicas=5
```

## HPA automatic

* Imperative way

```sh
kubectl autoscale deployment nginx-deployment --max=3 --cpu-percent=80
```

* Declarative way

```yaml
# hpa-definition.yaml
apiVersion: autoscaling/v2beta2
kind: HorizontalPodAutoscaler
metadata:
  name: nginx-hpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: nginx-deployment
  minReplicas: 1
  maxReplicas: 10
  metrics:
  - type: Resource
    resource:
      name: cpu
      target:
        type: Utilization
        averageUtilization: 80
```

# VPA (Vertical Pod Autoscaler)

## installation


````
