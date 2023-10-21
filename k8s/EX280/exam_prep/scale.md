# manual scale

```sh
oc scale deployment/longload --replicas 3
```

# auto scale (Horizontal Pod Autoscaler)

```sh
oc autoscale deployment/gitlab --name my-hpa --min=3 --max=5 --cpu-percent=60

watch oc get hpa my-hpa
```

```yaml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: longload
  labels:
    app: longload
spec:
  maxReplicas: 3
  minReplicas: 1
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: longload
  metrics:
  - type: Resource
    resource:
      name: memory
      target:
        type: Utilization
        averageUtilization: 60
```