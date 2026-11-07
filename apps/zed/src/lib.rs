
pub mod server;
pub mod types;

use server::SpiralServerManager;
use zed_extension_api::{
    self as zed, lsp::Completion, lsp::Symbol, settings::LspSettings, CodeLabel, CodeLabelSpan,
    Command, LanguageServerId, Result, Worktree,
};

pub struct SpiralExtension {
    server_manager: SpiralServerManager,
}

impl zed::Extension for SpiralExtension {
    fn new() -> Self {
        Self {
            server_manager: SpiralServerManager::new(),
        }
    }

    fn language_server_command(
        &mut self,
        language_server_id: &LanguageServerId,
        worktree: &Worktree,
    ) -> Result<Command> {
        self.server_manager
            .resolve_server(language_server_id, worktree)
    }

    fn language_server_workspace_configuration(
        &mut self,
        server_id: &LanguageServerId,
        worktree: &Worktree,
    ) -> Result<Option<zed::serde_json::Value>> {
        let settings = LspSettings::for_worktree(server_id.as_ref(), worktree)
            .ok()
            .and_then(|lsp_settings| lsp_settings.settings)
            .unwrap_or_else(server::SpiralSettings::configuration);
        Ok(Some(settings))
    }

    fn language_server_initialization_options(
        &mut self,
        _server_id: &LanguageServerId,
        _worktree: &Worktree,
    ) -> Result<Option<zed::serde_json::Value>> {
        Ok(Some(zed::serde_json::json!({
            "provideFormatter": true,
            "semanticTokens": true,
        })))
    }

    fn label_for_completion(
        &self,
        _language_server_id: &LanguageServerId,
        completion: Completion,
    ) -> Option<CodeLabel> {
        let label = completion.label;
        let end = label.len();
        Some(CodeLabel {
            code: label.clone(),
            spans: vec![CodeLabelSpan::literal(label, None)],
            filter_range: (0..end).into(),
        })
    }

    fn label_for_symbol(
        &self,
        _language_server_id: &LanguageServerId,
        symbol: Symbol,
    ) -> Option<CodeLabel> {
        let name = symbol.name;
        let end = name.len();
        Some(CodeLabel {
            code: name.clone(),
            spans: vec![CodeLabelSpan::literal(name, None)],
            filter_range: (0..end).into(),
        })
    }
}

zed::register_extension!(SpiralExtension);
