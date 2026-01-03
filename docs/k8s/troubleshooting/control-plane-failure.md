# Control Plane Failure Troubleshooting

https://kubernetes.io/docs/tasks/debug-application-cluster/debug-cluster/

kubectl cluster-info dump


```sh
# Check node status
kubectl get nodes
kubectl get pods
```

## Check control plane pods (if using kubeadm)

```sh
kubectl get pods -n kube-system
kubectl logs kube-apiserver-master -n kube-system
```

## Check systemd services on a master node (if deployed without kubeadm)

```sh
systemctl status kube-apiserver
systemctl status kube-controller-manager
systemctl status kube-scheduler
systemctl status etcd

journalctl -u kube-apiserver
```

## Worker Node Issues
### Check systemd services on a worker node

```sh
systemctl status kubelet
systemctl status kube-proxy
```

### Check Node status

```sh
kubectl get nodes
kubectl describe node <node-name>
```

### Check Kubelet logs

```sh
journalctl -u kubelet
systemctl status kubelet

# config path /var/lib/kubelet/config.yaml
```

### Check kubelet certificates

```sh
# check Issuer: CN; Not After;
openssl x509 -in /var/lib/kubelet/worker-node.crt -text
```