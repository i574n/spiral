use std::collections::{BTreeMap, BTreeSet};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub enum Direct {}

#[derive(Clone, Copy, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub enum Transitive {}

#[derive(Clone, Copy, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub struct GearFingerprint<S> {
    value: u64,
    stage: PhantomData<S>,
}

impl<S> GearFingerprint<S> {
    pub const fn value(self) -> u64 {
        self.value
    }
}

pub const fn direct_fingerprint(value: u64) -> GearFingerprint<Direct> {
    GearFingerprint {
        value,
        stage: PhantomData,
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct FingerprintNode {
    pub id: usize,
    pub direct: GearFingerprint<Direct>,
    pub dependencies: Vec<usize>,
}

const FNV_OFFSET: u64 = 0xcbf29ce484222325;
const FNV_PRIME: u64 = 0x100000001b3;

fn mix(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash ^= u64::from(*byte);
        hash = hash.wrapping_mul(FNV_PRIME);
    }
    hash
}

fn derive_one(
    id: usize,
    nodes: &BTreeMap<usize, FingerprintNode>,
    visiting: &mut BTreeSet<usize>,
    derived: &mut BTreeMap<usize, GearFingerprint<Transitive>>,
) -> Result<GearFingerprint<Transitive>, String> {
    if let Some(value) = derived.get(&id).copied() {
        return Ok(value);
    }
    let node = nodes
        .get(&id)
        .ok_or_else(|| format!("fingerprint graph references unknown Gear{id:04}"))?;
    if !visiting.insert(id) {
        return Err(format!("fingerprint graph contains a cycle at Gear{id:04}"));
    }

    let mut dependencies = node.dependencies.clone();
    dependencies.sort_unstable();
    dependencies.dedup();
    let mut hash = mix(FNV_OFFSET, b"spiral-gear-transitive\0");
    hash = mix(hash, &(node.id as u64).to_le_bytes());
    hash = mix(hash, &node.direct.value().to_le_bytes());
    for dependency in dependencies {
        let fingerprint = derive_one(dependency, nodes, visiting, derived)?;
        hash = mix(hash, &(dependency as u64).to_le_bytes());
        hash = mix(hash, &fingerprint.value().to_le_bytes());
    }

    visiting.remove(&id);
    let value = GearFingerprint {
        value: hash,
        stage: PhantomData,
    };
    derived.insert(id, value);
    Ok(value)
}

pub fn derive_transitive_fingerprints(
    nodes: &[FingerprintNode],
) -> Result<BTreeMap<usize, GearFingerprint<Transitive>>, String> {
    let by_id = nodes
        .iter()
        .cloned()
        .map(|node| (node.id, node))
        .collect::<BTreeMap<_, _>>();
    if by_id.len() != nodes.len() {
        return Err("fingerprint graph contains duplicate gear ids".to_owned());
    }
    let mut visiting = BTreeSet::new();
    let mut derived = BTreeMap::new();
    for id in by_id.keys().copied() {
        derive_one(id, &by_id, &mut visiting, &mut derived)?;
    }
    Ok(derived)
}

#[cfg(test)]
mod tests {
    use super::*;

    fn node(id: usize, direct: u64, dependencies: &[usize]) -> FingerprintNode {
        FingerprintNode {
            id,
            direct: direct_fingerprint(direct),
            dependencies: dependencies.to_vec(),
        }
    }

    #[test]
    fn upstream_change_invalidates_only_descendants() {
        let baseline = derive_transitive_fingerprints(&[
            node(0, 10, &[]),
            node(1, 20, &[0]),
            node(2, 30, &[1]),
            node(3, 40, &[]),
        ])
        .unwrap();
        let changed = derive_transitive_fingerprints(&[
            node(0, 11, &[]),
            node(1, 20, &[0]),
            node(2, 30, &[1]),
            node(3, 40, &[]),
        ])
        .unwrap();
        assert_ne!(baseline[&0], changed[&0]);
        assert_ne!(baseline[&1], changed[&1]);
        assert_ne!(baseline[&2], changed[&2]);
        assert_eq!(baseline[&3], changed[&3]);
    }

    #[test]
    fn dependency_order_does_not_change_identity() {
        let a = derive_transitive_fingerprints(&[
            node(0, 10, &[]),
            node(1, 20, &[]),
            node(2, 30, &[0, 1]),
        ])
        .unwrap();
        let b = derive_transitive_fingerprints(&[
            node(0, 10, &[]),
            node(1, 20, &[]),
            node(2, 30, &[1, 0]),
        ])
        .unwrap();
        assert_eq!(a[&2], b[&2]);
    }

    #[test]
    fn cycles_are_rejected() {
        let error =
            derive_transitive_fingerprints(&[node(0, 10, &[1]), node(1, 20, &[0])]).unwrap_err();
        assert!(error.contains("cycle"));
    }
}
