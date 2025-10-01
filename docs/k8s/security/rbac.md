# Role-Based Access Control (RBAC)

```sh

kubectl get roles
kubectl describe role pod-reader

kubectl get rolebindings

kubectl auth can-i create deployments --namespace=default --as=jane
```

## Role and RoleBinding

Namespace-scoped


## ClusterRole and ClusterRoleBinding

Cluster-scoped, also can grant namespace-scoped permissions.

```sh
# imperative way
kubectl create clusterrole pod-reader --verb=get,list,watch --resource=pods

kubectl create clusterrolebinding read-pods-global --clusterrole=pod-reader --user=j
```