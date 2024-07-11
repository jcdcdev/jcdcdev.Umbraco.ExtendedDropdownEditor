import {css, html, LitElement, PropertyValues} from 'lit';
import {customElement, property, state} from 'lit/decorators.js';
import {UmbElementMixin} from "@umbraco-cms/backoffice/element-api";
import {UUISelectElement, UUISelectEvent} from "@umbraco-cms/backoffice/external/uui";
import {EXTENDED_MARKDOWN_EDITOR_CONTEXT_TOKEN, ExtendedDropdownEditorContext} from "../context/extended-dropdown-editor.context";
import {UmbPropertyEditorUiElement} from "@umbraco-cms/backoffice/extension-registry";
import {UMB_CONTENT_PROPERTY_CONTEXT} from "@umbraco-cms/backoffice/content";
import {UmbPropertyEditorConfigCollection, UmbPropertyValueChangeEvent} from "@umbraco-cms/backoffice/property-editor";
import {map} from 'lit/directives/map.js';

@customElement('extended-dropdown-editor')
export class ExtendedDropdownEditor extends UmbElementMixin(LitElement) implements UmbPropertyEditorUiElement {

    #context: ExtendedDropdownEditorContext | undefined;

    #selection: Array<string> = [];

    @property({type: Array})
    public set value(value: Array<string> | string | undefined) {
        this.#selection = Array.isArray(value) ? value : value ? [value] : [];
    }

    public get value(): Array<string> | undefined {
        return this.#selection;
    }

    @state()
    loading: boolean = true;
    @state()
    initialised: boolean = false;
    @state()
    dataTypeKey?: string;
    @state()
    items?: Array<string>;

    constructor() {
        super();
        this.consumeContext(EXTENDED_MARKDOWN_EDITOR_CONTEXT_TOKEN, async (context) => {
            this.#context = context;
        });

        this.consumeContext(UMB_CONTENT_PROPERTY_CONTEXT, (context) => {
            context.dataType.subscribe((dataType) => {
                this.dataTypeKey = dataType?.unique
            }).unsubscribe();
        });
    }

    protected updated(_changedProperties: PropertyValues) {
        if (!this.initialised) {
            if (this.dataTypeKey && this.#context) {
                this.init();
            }
        }
    }

    private async init() {
        if (!this.#context || !this.dataTypeKey) {
            return;
        }
        const results = await this.#context.getItemsByDataTypeKey(this.dataTypeKey);
        this.loading = false;
        this.initialised = true;
        const items = results.data?.items;

        if (Array.isArray(items) && items.length > 0) {
            this._options = items.map((item) => ({name: item, value: item, selected: this.#selection.includes(item)}))
        }
    }

    public set config(config: UmbPropertyEditorConfigCollection | undefined) {
        if (!config) {
            return;
        }

        this._multiple = config.getValueByAlias<boolean>('multiple') ?? false;
    }

    @state()
    private _multiple: boolean = false;

    @state()
    private _options: Array<Option> = [];

    #onChange(event: UUISelectEvent) {
        const value = event.target.value as string;
        this.#setValue(value ? [value] : []);
    }

    #onChangeMulitple(event: Event & { target: HTMLSelectElement }) {
        const selected = event.target.selectedOptions;
        const value = selected ? Array.from(selected).map((option) => option.value) : [];
        this.#setValue(value);
    }

    #setValue(value: Array<string> | string | null | undefined) {
        if (!value) return;
        this.value = value;
        this.dispatchEvent(new UmbPropertyValueChangeEvent());
    }

    render() {
        return this._multiple ? this.#renderDropdownMultiple() : this.#renderDropdownSingle();
    }

    #renderDropdownMultiple() {
        return html`
            <select id="native" multiple @change=${this.#onChangeMulitple}>
                ${map(
                    this._options,
                    (item) => html`
                        <option value=${item.value} ?selected=${item.selected}>${item.name}</option>`,
                )}
            </select>
        `;
    }

    #renderDropdownSingle() {
        return html`
            <umb-input-dropdown-list .options=${this._options} @change=${this.#onChange}></umb-input-dropdown-list>
        `;
    }

    static styles = [
        UUISelectElement.styles,
        css`
            #native {
                height: auto;
            }
        `,
    ];
}

export default ExtendedDropdownEditor;
declare global {
    interface HTMLElementTagNameMap {
        'extended-dropdown-editor': ExtendedDropdownEditor;
    }
}
