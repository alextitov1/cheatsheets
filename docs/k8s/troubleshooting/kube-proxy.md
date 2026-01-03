# Kube-Proxy

`kube-proxy` is a network proxy that runs on each node in the cluster. `kube-proxy` maintains network rules on nodes. These network rules allow network communication to the Pods from network sessions inside or outside of the cluster.


In a cluster configured with kubeadm, you can find kube-proxy as a daemonset.


kubeproxy is responsible for watching services and endpoint associated with each service. When the client is going to connect to the service using the virtual IP the kubeproxy is responsible for sending traffic to actual pods.


If you run a `kubectl describe ds kube-proxy -n kube-system` you can see that the kube-proxy binary runs with following command inside the kube-proxy container.

```
Command:
    /usr/local/bin/kube-proxy
    --config=/var/lib/kube-proxy/config.conf
    --hostname-override=$(NODE_NAME)
```

So it fetches the configuration from a configuration file ie, /var/lib/kube-proxy/config.conf and we can override the hostname with the node name of at which the pod is running.

 

In the config file we define the clusterCIDR, kubeproxy mode, ipvs, iptables, bindaddress, kube-config etc.

 
## Troubleshooting issues related to kube-proxy

1. Check kube-proxy pod in the kube-system namespace is running

2. Check kube-proxy logs

3. Check `configmap` is correctly defined and the config file for running kube-proxy binary is correct.

4. kube-config is defined in the config map.

5. check kube-proxy is running inside the container

```sh
netstat -plan | grep kube-proxy
> tcp     0   0 0.0.0.0:30081        0.0.0.0:*          LISTEN      1/kube-proxy
> tcp     0   0 127.0.0.1:10249      0.0.0.0:*          LISTEN      1/kube-proxy
> tcp     0   0 172.17.0.12:33706    172.17.0.12:6443   ESTABLISHED 1/kube-proxy
> tcp6    0   0 :::10256             :::*               LISTEN      1/kube-proxy
```
