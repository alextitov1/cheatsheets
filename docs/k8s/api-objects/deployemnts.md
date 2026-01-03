````markdown
# Deployments

```sh
# Create a deployment from a YAML file
kubectl create -f deployment-definition.yaml

# Get deployments
kubectl get deployments

# Update a deployment (or create if it doesn't exist)
kubectl apply -f deployment-definition.yaml

# Update a deployment with a new image
kubectl set image deployment/myapp-deployment nginx=nginx:1.9.1

# Check rollout status
kubectl rollout status deployment/myapp-deployment

# Check rollout history and undo if necessary
kubectl rollout history deployment/myapp-deployment
kubectl rollout undo deployment/myapp-deployment
```
````
