program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralRecursiveNode = class
  public
    value: LongInt;
    next: TSpiralRecursiveNode;
    constructor Create(aValue: LongInt; aNext: TSpiralRecursiveNode);
    function CloneNode: TSpiralRecursiveNode;
    destructor Destroy; override;
  end;
  TSpiralRef_slot = ^TSpiralRecursiveNode;
  TSpiralRef_q = ^LongInt;
  TSpiralRef_w = ^LongInt;
  TSpiralStackRefs = record
    slot: TSpiralRef_slot;
    q: TSpiralRef_q;
    w: TSpiralRef_w;
  end;

constructor TSpiralRecursiveNode.Create(aValue: LongInt; aNext: TSpiralRecursiveNode);
begin
  inherited Create;
  value := aValue;
  next := aNext;
end;

function TSpiralRecursiveNode.CloneNode: TSpiralRecursiveNode;
begin
  if Assigned(next) then
    Result := TSpiralRecursiveNode.Create(value, next.CloneNode)
  else
    Result := TSpiralRecursiveNode.Create(value, nil);
end;

destructor TSpiralRecursiveNode.Destroy;
begin
  next.Free;
  next := nil;
  inherited Destroy;
end;

procedure SpiralAssignRecursiveOption(var target: TSpiralRecursiveNode; const value: TSpiralRecursiveNode);
var
  nextValue: TSpiralRecursiveNode;
begin
  if Assigned(value) then nextValue := value.CloneNode else nextValue := nil;
  target.Free;
  target := nextValue;
end;

function SpiralRecursiveOptionValue(const value: TSpiralRecursiveNode): LongInt;
begin
  if Assigned(value) then Result := value.value else Result := 0;
end;

function SpiralRecursiveOptionNextValue(const value: TSpiralRecursiveNode): LongInt;
begin
  if Assigned(value) and Assigned(value.next) then Result := value.next.value else Result := 0;
end;

function SpiralMain: LongInt;
var
  a_slot_storage: TSpiralRecursiveNode;
  a_q_storage: LongInt;
  a_w_storage: LongInt;
  a, b: TSpiralStackRefs;
  next_recursive_option_value: TSpiralRecursiveNode;
begin
  a_slot_storage := TSpiralRecursiveNode.Create(11, TSpiralRecursiveNode.Create(13, nil));
  a.slot := @a_slot_storage;
  a_q_storage := 5;
  a.q := @a_q_storage;
  a_w_storage := 6;
  a.w := @a_w_storage;
  try
    b := a;
    if a.q^ = 5 then begin
      next_recursive_option_value := TSpiralRecursiveNode.Create(19, TSpiralRecursiveNode.Create(23, nil));
      try
        SpiralAssignRecursiveOption(a.slot^, next_recursive_option_value);
      finally
        next_recursive_option_value.Free;
        next_recursive_option_value := nil;
      end;
    end else begin
      next_recursive_option_value := nil;
      try
        SpiralAssignRecursiveOption(a.slot^, next_recursive_option_value);
      finally
        next_recursive_option_value.Free;
        next_recursive_option_value := nil;
      end;
    end;
    a.q^ := SpiralRecursiveOptionValue(b.slot^);
    a.w^ := SpiralRecursiveOptionNextValue(a.slot^);
    Result := LongInt(a.q^ + a.w^);
  finally
    a_slot_storage.Free;
    a_slot_storage := nil;
  end;
end;

begin
  Halt(SpiralMain);
end.
