program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Recursive1 = class;
  Recursive0 = class;
  Recursive1 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: Recursive0;
  end;
  Recursive0 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: Recursive1;
  end;

procedure RecursiveDrop1(var value: Recursive1); forward;
procedure RecursiveDrop0(var value: Recursive0); forward;

function RecursiveCreate1_0(v0: Recursive0): Recursive1;
begin
  Result := Recursive1.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
  Result.v0 := v0;
end;
function RecursiveCreate1_1: Recursive1;
begin
  Result := Recursive1.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
end;
function RecursiveTag1(value: Recursive1): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField1_0(value: Recursive1): Recursive0;
begin
  if value.Tag <> 0 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
procedure RecursiveClone1(value: Recursive1);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop1(var value: Recursive1);
var
  child: Recursive0;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child := nil;
    if value.Tag = 0 then child := value.v0;
    value.Free;
    value := nil;
    if child <> nil then RecursiveDrop0(child);
  end
  else value := nil;
end;

function RecursiveCreate0_0(v0: Recursive1): Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
  Result.v0 := v0;
end;
function RecursiveCreate0_1: Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
end;
function RecursiveTag0(value: Recursive0): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField0_0(value: Recursive0): Recursive1;
begin
  if value.Tag <> 0 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
procedure RecursiveClone0(value: Recursive0);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop0(var value: Recursive0);
var
  child: Recursive1;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child := nil;
    if value.Tag = 0 then child := value.v0;
    value.Free;
    value := nil;
    if child <> nil then RecursiveDrop1(child);
  end
  else value := nil;
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v5: Recursive0;
  v1: Recursive0;
  v2: Recursive1;
begin
  v0 := True;
  if v0 then begin
    v1 := RecursiveCreate0_1();
    RecursiveClone0(v1);
    v2 := RecursiveCreate1_0(v1);
    RecursiveDrop0(v1);
    v5 := RecursiveCreate0_0(v2);
  end else begin
    v5 := RecursiveCreate0_1();
  end;
  if (RecursiveTag0(v5) = 0) then begin
    RecursiveDrop0(v5);
    Exit(0);
  end else begin
    RecursiveDrop0(v5);
    Exit(0);
  end;
end;

begin
  Halt(SpiralMain);
end.
