use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ModuleRoute {
    Alias {
        provider: usize,
        alias: String,
        target: String,
    },
    Concrete {
        provider: usize,
        path: String,
    },
    Unresolved {
        provider: usize,
        path: String,
    },
}

fn identifier(value: &str) -> bool {
    let mut chars = value.chars();
    let Some(first) = chars.next() else {
        return false;
    };
    (first == '_' || first.is_alphabetic())
        && chars
            .all(|character| character == '_' || character == '\'' || character.is_alphanumeric())
}

fn simple_module_path(value: &str) -> bool {
    !value.is_empty() && value.split('.').all(identifier)
}

fn module_binding(line: &str) -> Option<(String, Option<String>)> {
    let rest = line.trim().strip_prefix("module ")?;
    let (name, target) = rest.split_once('=')?;
    let name = name.trim();
    let target = target.trim();
    if !identifier(name) {
        return None;
    }
    if target.is_empty() {
        Some((name.to_owned(), None))
    } else if simple_module_path(target) {
        Some((name.to_owned(), Some(target.to_owned())))
    } else {
        None
    }
}

fn resolve_route(
    provider: usize,
    path: String,
    aliases: &BTreeMap<(usize, String), String>,
    concrete_modules: &BTreeMap<String, usize>,
    visited: &mut BTreeSet<(usize, String)>,
) -> ModuleRoute {
    let Some((root, tail)) = path.split_once('.') else {
        return ModuleRoute::Unresolved { provider, path };
    };
    let key = (provider, root.to_owned());
    if !visited.insert(key.clone()) {
        return ModuleRoute::Unresolved { provider, path };
    }
    if let Some(target) = aliases.get(&key) {
        let expanded = format!("{target}.{tail}");
        return ModuleRoute::Alias {
            provider,
            alias: root.to_owned(),
            target: expanded.clone(),
        }
        .resolve(aliases, concrete_modules, visited);
    }
    concrete_modules.get(root).copied().map_or(
        ModuleRoute::Unresolved {
            provider,
            path: path.clone(),
        },
        |provider| ModuleRoute::Concrete { provider, path },
    )
}

impl ModuleRoute {
    fn resolve(
        self,
        aliases: &BTreeMap<(usize, String), String>,
        concrete_modules: &BTreeMap<String, usize>,
        visited: &mut BTreeSet<(usize, String)>,
    ) -> Self {
        match self {
            Self::Alias {
                provider, target, ..
            } => resolve_route(provider, target, aliases, concrete_modules, visited),
            route => route,
        }
    }
}

pub fn resolve_module_abbreviations(
    plan: &SplitPlan,
    declaration_shards: &[usize],
) -> BTreeMap<(usize, String), String> {
    let mut concrete_candidates = BTreeMap::<String, BTreeSet<usize>>::new();
    let mut aliases = BTreeMap::<(usize, String), String>::new();
    for declaration in &plan.declarations {
        let provider = declaration_shards[declaration.id.0];
        for line in declaration.text.lines() {
            match module_binding(line) {
                Some((name, None)) => {
                    concrete_candidates
                        .entry(name)
                        .or_default()
                        .insert(provider);
                }
                Some((name, Some(target))) => {
                    aliases.insert((provider, name), target);
                }
                None => {}
            }
        }
    }
    let concrete_modules = concrete_candidates
        .into_iter()
        .filter_map(|(name, providers)| {
            (providers.len() == 1).then(|| (name, *providers.first().expect("single provider")))
        })
        .collect::<BTreeMap<_, _>>();
    aliases
        .iter()
        .filter_map(|((provider, alias), target)| {
            let route = resolve_route(
                *provider,
                target.clone(),
                &aliases,
                &concrete_modules,
                &mut BTreeSet::new(),
            );
            match route {
                ModuleRoute::Concrete {
                    provider: target_provider,
                    path,
                } => Some((
                    (*provider, alias.clone()),
                    format!("spiral_compiler_Part{target_provider:04}.{path}"),
                )),
                ModuleRoute::Alias { .. } | ModuleRoute::Unresolved { .. } => None,
            }
        })
        .collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn module_bindings_distinguish_concrete_modules_and_abbreviations() {
        assert_eq!(
            module_binding("    module CompilerIdentityKernel ="),
            Some(("CompilerIdentityKernel".to_owned(), None))
        );
        assert_eq!(
            module_binding("    module ContentDigest = CompilerIdentityKernel.ContentDigest"),
            Some((
                "ContentDigest".to_owned(),
                Some("CompilerIdentityKernel.ContentDigest".to_owned())
            ))
        );
    }

    #[test]
    fn a_local_alias_resolves_to_the_concrete_cross_assembly_module() {
        let aliases = BTreeMap::from([(
            (201, "ContentDigest".to_owned()),
            "CompilerIdentityKernel.ContentDigest".to_owned(),
        )]);
        let concrete = BTreeMap::from([("CompilerIdentityKernel".to_owned(), 48)]);
        assert_eq!(
            resolve_route(
                201,
                aliases[&(201, "ContentDigest".to_owned())].clone(),
                &aliases,
                &concrete,
                &mut BTreeSet::new(),
            ),
            ModuleRoute::Concrete {
                provider: 48,
                path: "CompilerIdentityKernel.ContentDigest".to_owned(),
            }
        );
    }
}
