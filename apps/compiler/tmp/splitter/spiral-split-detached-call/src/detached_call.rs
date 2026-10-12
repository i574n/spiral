use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Unproven;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Certified;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DetachedCallEvidence {
    pub rewritten_calls: usize,
    pub prior_hoisted_calls: usize,
    pub owner_mentions: usize,
    pub hoisted_mentions: usize,
    pub owner_line_calls: usize,
    pub owner_code_mentions: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum DetachedCallDisposition {
    Rewritten {
        calls: usize,
    },
    UnusedBinding,
    ResidualReference {
        owner_mentions: usize,
        hoisted_mentions: usize,
        owner_line_calls: usize,
        owner_code_mentions: usize,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DetachedCallAssessment<S> {
    disposition: DetachedCallDisposition,
    stage: PhantomData<fn() -> S>,
}

impl DetachedCallAssessment<Certified> {
    #[must_use]
    pub fn disposition(&self) -> &DetachedCallDisposition {
        &self.disposition
    }

    #[must_use]
    pub fn permits_hoist(&self) -> bool {
        matches!(
            self.disposition,
            DetachedCallDisposition::Rewritten { .. } | DetachedCallDisposition::UnusedBinding
        )
    }

    #[must_use]
    pub fn is_unused_binding(&self) -> bool {
        matches!(self.disposition, DetachedCallDisposition::UnusedBinding)
    }
}

#[must_use]
pub fn certify_detached_call(evidence: DetachedCallEvidence) -> DetachedCallAssessment<Certified> {
    let calls = evidence.rewritten_calls + evidence.prior_hoisted_calls;
    let disposition = if calls > 0 {
        DetachedCallDisposition::Rewritten { calls }
    } else if evidence.owner_mentions == 0
        && evidence.hoisted_mentions == 0
        && evidence.owner_line_calls == 0
        && evidence.owner_code_mentions == 0
    {
        DetachedCallDisposition::UnusedBinding
    } else {
        DetachedCallDisposition::ResidualReference {
            owner_mentions: evidence.owner_mentions,
            hoisted_mentions: evidence.hoisted_mentions,
            owner_line_calls: evidence.owner_line_calls,
            owner_code_mentions: evidence.owner_code_mentions,
        }
    };
    DetachedCallAssessment {
        disposition,
        stage: PhantomData,
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    fn evidence() -> DetachedCallEvidence {
        DetachedCallEvidence {
            rewritten_calls: 0,
            prior_hoisted_calls: 0,
            owner_mentions: 0,
            hoisted_mentions: 0,
            owner_line_calls: 0,
            owner_code_mentions: 0,
        }
    }

    #[test]
    fn rewritten_calls_are_owned() {
        let mut proof = evidence();
        proof.rewritten_calls = 2;
        proof.prior_hoisted_calls = 1;
        let certified = certify_detached_call(proof);
        assert_eq!(
            certified.disposition(),
            &DetachedCallDisposition::Rewritten { calls: 3 }
        );
        assert!(certified.permits_hoist());
    }

    #[test]
    fn zero_consumer_function_binding_is_safe_to_hoist() {
        let certified = certify_detached_call(evidence());
        assert_eq!(
            certified.disposition(),
            &DetachedCallDisposition::UnusedBinding
        );
        assert!(certified.permits_hoist());
        assert!(certified.is_unused_binding());
    }

    #[test]
    fn residual_owner_reference_stays_fail_closed() {
        let mut proof = evidence();
        proof.owner_mentions = 1;
        let certified = certify_detached_call(proof);
        assert!(matches!(
            certified.disposition(),
            DetachedCallDisposition::ResidualReference { .. }
        ));
        assert!(!certified.permits_hoist());
    }

    #[test]
    fn lexical_code_reference_stays_fail_closed() {
        let mut proof = evidence();
        proof.owner_code_mentions = 1;
        let certified = certify_detached_call(proof);
        assert!(matches!(
            certified.disposition(),
            DetachedCallDisposition::ResidualReference { .. }
        ));
        assert!(!certified.permits_hoist());
    }
}
