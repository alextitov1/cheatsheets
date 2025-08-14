k8s version

kubectl get nodes

kubeadm upgrade plan

kubectl drain node1 --ignore-daemonsets

apt-get install kubeadm=1.33.0-1.1

kubeadm upgrade plan v1.33.0

kubeadm upgrade apply v1.33.0

apt-get install kubelet=1.33.0-1.1
systemctl daemon-reload
systemctl restart kubelet

#-mark node as schedulable
kubectl uncordon node1


# kubeadm upgrade node
apt-get install kubeadm=1.33.0-1.1

kubeadm upgrade node