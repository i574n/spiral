program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Recursive0 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: LongInt;
    v1: Recursive0;
    v2: Recursive0;
  end;

function RecursiveCreate0_0: Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
end;
function RecursiveCreate0_1(v0: LongInt; v1: Recursive0; v2: Recursive0): Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;
function RecursiveTag0(value: Recursive0): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField0_0(value: Recursive0): LongInt;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
function RecursiveField0_1(value: Recursive0): Recursive0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v1;
end;
function RecursiveField0_2(value: Recursive0): Recursive0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v2;
end;
procedure RecursiveClone0(value: Recursive0);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop0(var value: Recursive0);
var
  child0: Recursive0;
  child1: Recursive0;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child0 := nil;
    if value.Tag = 1 then child0 := value.v1;
    child1 := nil;
    if value.Tag = 1 then child1 := value.v2;
    value.Free;
    value := nil;
    if child0 <> nil then RecursiveDrop0(child0);
    if child1 <> nil then RecursiveDrop0(child1);
  end
  else value := nil;
end;

function sum0(v0: Recursive0): LongInt;
var
  v1: LongInt;
  v2: Recursive0;
  v3: Recursive0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  if (RecursiveTag0(v0) = 0) then begin
    RecursiveDrop0(v0);
    Exit(0);
  end else begin
    v1 := RecursiveField0_0(v0);
    v2 := RecursiveField0_1(v0);
    v3 := RecursiveField0_2(v0);
    RecursiveClone0(v2);
    RecursiveClone0(v2);
    RecursiveClone0(v3);
    RecursiveDrop0(v0);
    v4 := sum0(v2);
    RecursiveClone0(v3);
    RecursiveDrop0(v2);
    v5 := sum0(v3);
    RecursiveDrop0(v3);
    v6 := (v4 + v5);
    v7 := (v1 + v6);
    Exit(v7);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Recursive0;
  v3: Recursive0;
  v4: Recursive0;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := RecursiveCreate0_0();
  RecursiveClone0(v2);
  RecursiveClone0(v2);
  v3 := RecursiveCreate0_1(v1, v2, v2);
  RecursiveClone0(v3);
  RecursiveClone0(v3);
  RecursiveDrop0(v2);
  v4 := RecursiveCreate0_1(v0, v3, v3);
  RecursiveClone0(v4);
  RecursiveDrop0(v3);
  v5 := sum0(v4);
  RecursiveDrop0(v4);
  v6 := (v5 - 5);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
