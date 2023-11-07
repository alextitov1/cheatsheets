Ansible provides three modules to work with systemd: `service`, `systemd`, and `service_facts`.


```yaml
---
- name: Configure 2nd network interface
  hosts: servers
  become: true

  tasks:
    - name: Confirm NetworkManager is running
      service:
        name: NetworkManager
        state: started
        enabled: true
```
